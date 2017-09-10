namespace XRITTune {
  partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.falseColorBox = new System.Windows.Forms.PictureBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radianceOffsetLabel = new System.Windows.Forms.Label();
            this.thermalOffset = new System.Windows.Forms.TrackBar();
            this.radianceOffset = new System.Windows.Forms.TrackBar();
            this.thermalOffsetLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lutBox = new System.Windows.Forms.PictureBox();
            this.lutLoadDialog = new System.Windows.Forms.OpenFileDialog();
            this.defaultLut = new System.Windows.Forms.Button();
            this.loadNewLut = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.falseColorBox)).BeginInit();
            this.falseColorBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thermalOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radianceOffset)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lutBox)).BeginInit();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.falseColorBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1006, 610);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 2);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 521);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1000, 86);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // falseColorBox
            // 
            this.falseColorBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.falseColorBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.falseColorBox.Controls.Add(this.loadingLabel);
            this.falseColorBox.Location = new System.Drawing.Point(3, 3);
            this.falseColorBox.Name = "falseColorBox";
            this.falseColorBox.Size = new System.Drawing.Size(512, 512);
            this.falseColorBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.falseColorBox.TabIndex = 2;
            this.falseColorBox.TabStop = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.loadingLabel.Location = new System.Drawing.Point(120, 240);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(272, 33);
            this.loadingLabel.TabIndex = 13;
            this.loadingLabel.Text = "Generating Image...";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.radianceOffsetLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.thermalOffset, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.radianceOffset, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.thermalOffsetLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(521, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(482, 512);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // radianceOffsetLabel
            // 
            this.radianceOffsetLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radianceOffsetLabel.AutoSize = true;
            this.radianceOffsetLabel.Location = new System.Drawing.Point(78, 18);
            this.radianceOffsetLabel.Name = "radianceOffsetLabel";
            this.radianceOffsetLabel.Size = new System.Drawing.Size(84, 13);
            this.radianceOffsetLabel.TabIndex = 10;
            this.radianceOffsetLabel.Text = "Radiance Offset";
            // 
            // thermalOffset
            // 
            this.thermalOffset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thermalOffset.Location = new System.Drawing.Point(244, 53);
            this.thermalOffset.Maximum = 127;
            this.thermalOffset.Minimum = -127;
            this.thermalOffset.Name = "thermalOffset";
            this.thermalOffset.Size = new System.Drawing.Size(235, 44);
            this.thermalOffset.TabIndex = 8;
            this.thermalOffset.Scroll += new System.EventHandler(this.thermalOffset_Scroll);
            // 
            // radianceOffset
            // 
            this.radianceOffset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radianceOffset.Location = new System.Drawing.Point(244, 3);
            this.radianceOffset.Maximum = 127;
            this.radianceOffset.Minimum = -127;
            this.radianceOffset.Name = "radianceOffset";
            this.radianceOffset.Size = new System.Drawing.Size(235, 44);
            this.radianceOffset.TabIndex = 11;
            this.radianceOffset.Scroll += new System.EventHandler(this.radianceOffset_Scroll);
            // 
            // thermalOffsetLabel
            // 
            this.thermalOffsetLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.thermalOffsetLabel.AutoSize = true;
            this.thermalOffsetLabel.Location = new System.Drawing.Point(82, 68);
            this.thermalOffsetLabel.Name = "thermalOffsetLabel";
            this.thermalOffsetLabel.Size = new System.Drawing.Size(76, 13);
            this.thermalOffsetLabel.TabIndex = 12;
            this.thermalOffsetLabel.Text = "Thermal Offset";
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.loadNewLut);
            this.groupBox1.Controls.Add(this.defaultLut);
            this.groupBox1.Controls.Add(this.lutBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 378);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loaded LUT";
            // 
            // lutBox
            // 
            this.lutBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lutBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lutBox.Location = new System.Drawing.Point(6, 19);
            this.lutBox.Name = "lutBox";
            this.lutBox.Size = new System.Drawing.Size(256, 256);
            this.lutBox.TabIndex = 12;
            this.lutBox.TabStop = false;
            this.lutBox.Click += new System.EventHandler(this.lutBox_Click);
            // 
            // lutLoadDialog
            // 
            this.lutLoadDialog.Filter = "Image Files|*.png;*.jpg;*.bmp";
            // 
            // defaultLut
            // 
            this.defaultLut.Location = new System.Drawing.Point(268, 19);
            this.defaultLut.Name = "defaultLut";
            this.defaultLut.Size = new System.Drawing.Size(202, 23);
            this.defaultLut.TabIndex = 13;
            this.defaultLut.Text = "Default LUT";
            this.defaultLut.UseVisualStyleBackColor = true;
            this.defaultLut.Click += new System.EventHandler(this.defaultLut_Click);
            // 
            // loadNewLut
            // 
            this.loadNewLut.Location = new System.Drawing.Point(268, 48);
            this.loadNewLut.Name = "loadNewLut";
            this.loadNewLut.Size = new System.Drawing.Size(202, 23);
            this.loadNewLut.TabIndex = 14;
            this.loadNewLut.Text = "Load LUT";
            this.loadNewLut.UseVisualStyleBackColor = true;
            this.loadNewLut.Click += new System.EventHandler(this.lutBox_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 610);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "XRIT Tuner";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.falseColorBox)).EndInit();
            this.falseColorBox.ResumeLayout(false);
            this.falseColorBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thermalOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radianceOffset)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lutBox)).EndInit();
            this.ResumeLayout(false);

    }

        #endregion
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox falseColorBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label radianceOffsetLabel;
        private System.Windows.Forms.TrackBar thermalOffset;
        private System.Windows.Forms.TrackBar radianceOffset;
        private System.Windows.Forms.Label thermalOffsetLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox lutBox;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.OpenFileDialog lutLoadDialog;
        private System.Windows.Forms.Button loadNewLut;
        private System.Windows.Forms.Button defaultLut;
    }
}

