using OpenSatelliteProject;
using OpenSatelliteProject.Geo;
using OpenSatelliteProject.PacketData;
using OpenSatelliteProject.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRITTune {
    public partial class MainForm : Form {
        string irfilename = "./OR_ABI-L2-CMIPF-M3C13_G16_s20170861545382_e20170861556160_c20170861556231.lrit";
        string visFilename = "./OR_ABI-L2-CMIPF-M3C02_G16_s20170861545382_e20170861556149_c20170861556217.lrit";
        object lutLocker = new object();
        Bitmap visBmp = null;
        Bitmap irBmp = null;
        Bitmap falseColorBmp = null;
        Bitmap lutBmp = null;

        GeoConverter gc;

        int[] LUT = new int[256 * 256];

        bool ParametersChanged = false;
        bool LUTChanged = false;
        bool LUTLoaded = false;

        public int FLSCLRLUT(byte thermal, byte visible) {
            byte num = (byte)Math.Max(Math.Min(thermal + OpenSatelliteProject.Presets.ThermalOffset, 0xff), 0);
            byte num2 = (byte)Math.Max(Math.Min(visible + OpenSatelliteProject.Presets.RadianceOffset, 0xff), 0);
            return LUT[(num2 * 0x100) + num];
        }

        public async Task WaitLUTLoad() {
            await Task.Run(() => {
                while(true) {
                    Monitor.Enter(lutLocker);
                    if (LUTLoaded) {
                        Monitor.Exit(lutLocker);
                        break;
                    }
                    Monitor.Exit(lutLocker);
                    Thread.Sleep(10);
                }
            });
        }

        public async Task GenerateFalseColor() {
            await Task.Run(async () => {
                if (visBmp == null || irBmp == null) {
                    return;
                }
                await WaitLUTLoad();
                falseColorBmp = visBmp.Clone(new Rectangle(0, 0, visBmp.Width, visBmp.Height), visBmp.PixelFormat);
                ImageTools.ApplyCurve(OpenSatelliteProject.Presets.NEW_VIS_FALSE_CURVE, ref falseColorBmp);

                Monitor.Enter(lutLocker);
                ImageTools.Apply2DLut(FLSCLRLUT, ref falseColorBmp, irBmp);
                Monitor.Exit(lutLocker);

                if (falseColorBox.InvokeRequired) {
                    falseColorBox.Invoke((MethodInvoker)(() => {
                        falseColorBox.Image = falseColorBmp;
                    }));
                } else {
                    falseColorBox.Image = falseColorBmp;
                }
                HideGeneratingLabel();
            });
        }

        public async void LoadLUT() {
            await Task.Run(async () => {
                LockControls();
                byte[] buffer = Tools.ReadFileFromOSPAssembly("falsecolor.png");
                if (buffer != null) {
                    using (MemoryStream stream = new MemoryStream(buffer)) {
                        lutBmp = new Bitmap(stream);
                    }
                }
                Monitor.Enter(lutLocker);
                LUTLoaded = false;
                Monitor.Exit(lutLocker);
                
                LUTChanged = true;
                ParametersChanged = true;
                await RefreshLUT();
                UnlockControls();
            });
        }

        public async Task RefreshLUT() {
            await Task.Run(() => {
                if (LUTChanged) {
                    LockControls();
                    lock (lutLocker) {
                        for (int i = 0; i < 256; i++) {
                            for (int j = 0; j < 256; j++) {
                                LUT[(i * 256) + j] = lutBmp.GetPixel(j, i).ToArgb();
                            }
                        }
                    }
                    if (lutBox.InvokeRequired) {
                        lutBox.Invoke((MethodInvoker)(() => {
                            lock (lutLocker) {
                                lutBox.Image = lutBmp;
                            }
                        }));
                    } else {
                        lutBox.Image = lutBmp;
                    }
                    UnlockControls();
                }

                Monitor.Enter(lutLocker);
                LUTLoaded = true;
                LUTChanged = false;
                Monitor.Exit(lutLocker);
            });
        }

        public async void LoadLRIT() {
            await Task.Run(async () => {
                LockControls();
                UIConsole.Log($"Loading Headers from Visible file at {visFilename}");
                XRITHeader header = FileParser.GetHeaderFromFile(visFilename);
                Regex x = new Regex(@".*\((.*)\)", RegexOptions.IgnoreCase);
                var regMatch = x.Match(header.ImageNavigationHeader.ProjectionName);
                float satelliteLongitude = float.Parse(regMatch.Groups[1].Captures[0].Value, CultureInfo.InvariantCulture);
                var inh = header.ImageNavigationHeader;
                gc = new GeoConverter(satelliteLongitude, inh.ColumnOffset, inh.LineOffset, inh.ColumnScalingFactor, inh.LineScalingFactor);
                var od = new OrganizerData();
                od.Segments.Add(0, visFilename);
                od.FirstSegment = 0;
                od.Columns = header.ImageStructureHeader.Columns;
                od.Lines = header.ImageStructureHeader.Lines;
                od.ColumnOffset = inh.ColumnOffset;
                od.PixelAspect = 1;
                UIConsole.Log($"Generating Visible Bitmap");
                visBmp = ImageTools.GenerateFullImage(od);
                visBmp = ImageTools.ResizeImage(visBmp, visBmp.Width / 4, visBmp.Height / 4, true);

                od = new OrganizerData();
                od.Segments.Add(0, irfilename);
                od.FirstSegment = 0;
                od.Columns = header.ImageStructureHeader.Columns;
                od.Lines = header.ImageStructureHeader.Lines;
                od.ColumnOffset = inh.ColumnOffset;
                od.PixelAspect = 1;
                UIConsole.Log($"Generating Infrared Bitmap");
                irBmp = ImageTools.GenerateFullImage(od);
                irBmp = ImageTools.ResizeImage(irBmp, irBmp.Width / 4, irBmp.Height / 4, true);

                UIConsole.Log("Generating False Color");
                await GenerateFalseColor();
                UIConsole.Log("Done");
                UnlockControls();
            });
        }
        public MainForm() {
            InitializeComponent();

            UIConsole.MessageAvailable += UIConsole_MessageAvailable;
            UIConsole.Log("Starting Load LRIT");
            UIConsole.Log("Loading Defaults");

            radianceOffset.Value = OpenSatelliteProject.Presets.RadianceOffset;
            thermalOffset.Value = OpenSatelliteProject.Presets.ThermalOffset;
            radianceOffsetLabel.Text = $"Radiance Offset: {radianceOffset.Value}";
            thermalOffsetLabel.Text = $"Thermal Offset: {thermalOffset.Value}";

            LoadLRIT();
            LoadLUT();

            loadingLabel.Parent = falseColorBox;
            loadingLabel.Anchor = AnchorStyles.None;
            RefreshUI();
        }

        private void UIConsole_MessageAvailable(ConsoleMessage data) {
            if (richTextBox1.InvokeRequired) {
                richTextBox1.Invoke((MethodInvoker)(() => UIConsole_MessageAvailable(data)));
            } else {
                switch (data.Priority) {
                    case ConsoleMessagePriority.DEBUG:
                        richTextBox1.AppendText($"{data.TimeStamp.ToLocalTime()} - {data.Message}{Environment.NewLine}", Color.Maroon);
                        break;
                    case ConsoleMessagePriority.INFO:
                        richTextBox1.AppendText($"{data.TimeStamp.ToLocalTime()} - {data.Message}{Environment.NewLine}", Color.DarkGreen);
                        break;
                    case ConsoleMessagePriority.ERROR:
                        richTextBox1.AppendText($"{data.TimeStamp.ToLocalTime()} - {data.Message}{Environment.NewLine}", Color.DarkRed);
                        break;
                    case ConsoleMessagePriority.WARN:
                        richTextBox1.AppendText($"{data.TimeStamp.ToLocalTime()} - {data.Message}{Environment.NewLine}", Color.DarkOrange);
                        break;
                }
            }
        }

        CountDown cd = new CountDown();

        public void LockControls() {
            if (loadNewLut.InvokeRequired) {
                loadNewLut.Invoke((MethodInvoker)(() => { LockControls(); }));
            } else {
                cd.Inc();
                loadNewLut.Enabled = false;
                defaultLut.Enabled = false;
                thermalOffset.Enabled = false;
                radianceOffset.Enabled = false;
            }
        }

        public void UnlockControls() {
            if (loadNewLut.InvokeRequired) {
                loadNewLut.Invoke((MethodInvoker)(() => { UnlockControls(); }));
            } else {
                cd.Dec();
                if (cd.IsZero()) {
                    loadNewLut.Enabled = true;
                    defaultLut.Enabled = true;
                    thermalOffset.Enabled = true;
                    radianceOffset.Enabled = true;
                }
            }
        }

        private void ShowGeneratingLabel() {
            if (loadingLabel.InvokeRequired) {
                loadingLabel.Invoke((MethodInvoker)(() => { ShowGeneratingLabel(); }));
            } else {
                loadingLabel.Visible = true;
            }
        }
        private void HideGeneratingLabel() {
            if (loadingLabel.InvokeRequired) {
                loadingLabel.Invoke((MethodInvoker)(() => { HideGeneratingLabel(); }));
            } else {
                loadingLabel.Visible = false;
            }
        }

        private async void updateTimer_Tick(object sender, EventArgs e) {
            if (ParametersChanged) {
                ShowGeneratingLabel();
                await RefreshLUT();
                await GenerateFalseColor();
                ParametersChanged = false;
            }
        }

        private void radianceOffset_Scroll(object sender, EventArgs e) {
            OpenSatelliteProject.Presets.RadianceOffset = radianceOffset.Value;
            radianceOffsetLabel.Text = $"Radiance Offset: {radianceOffset.Value}";
            ParametersChanged = true;
        }

        private void thermalOffset_Scroll(object sender, EventArgs e) {
            OpenSatelliteProject.Presets.ThermalOffset = thermalOffset.Value;
            thermalOffsetLabel.Text = $"Thermal Offset: {thermalOffset.Value}";
            ParametersChanged = true;
        }

        private void lutBox_Click(object sender, EventArgs e) {
            if (lutLoadDialog.ShowDialog() == DialogResult.OK) {
                LockControls();
                try {
                    UIConsole.Log($"Selected {lutLoadDialog.FileName} for new LUT");
                    var ifile = Bitmap.FromFile(lutLoadDialog.FileName);
                    if (ifile.Width != 256 || ifile.Height != 256) {
                        throw new ArgumentException($"The image size should be 256x256 pixels. Got {ifile.Width}x{ifile.Height}");
                    }

                    lutBmp = new Bitmap(ifile);
                    lutBmp = lutBmp.ToFormat(System.Drawing.Imaging.PixelFormat.Format32bppPArgb, true);
                    UIConsole.Log("New LUT loaded");
                    Monitor.Enter(lutLocker);
                    LUTChanged = true;
                    LUTLoaded = false;
                    Monitor.Exit(lutLocker);
                    ParametersChanged = true;
                } catch (Exception ex) {
                    MessageBox.Show($"There was an error loading the file:{Environment.NewLine}{ex.Message}");
                }
                UnlockControls();
            }
        }

        private void RefreshUI() {
            loadingLabel.Left = (falseColorBox.ClientSize.Width - loadingLabel.Width) / 2;
            loadingLabel.Top = (falseColorBox.ClientSize.Height - loadingLabel.Height) / 2;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e) {
            RefreshUI();
        }

        private void defaultLut_Click(object sender, EventArgs e) {
            LoadLUT();
        }
    }
}
