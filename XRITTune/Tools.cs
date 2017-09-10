using OpenSatelliteProject;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace XRITTune {
    public static class Tools {
        public static Assembly GetAssemblyByName(string name) {
            return AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == name);
        }
        public static byte[] ReadFileFromOSPAssembly(string filename) {
            byte[] buffer = null;
            Assembly xritAssembly = GetAssemblyByName("XRIT");
            try {
                using (Stream stream = xritAssembly.GetManifestResourceStream(string.Format("OpenSatelliteProject.LUT.{0}", filename))) {
                    int num2;
                    buffer = new byte[stream.Length];
                    for (int i = 0; i < stream.Length; i += num2) {
                        num2 = ((stream.Length - i) > 0x1000L) ? 0x1000 : (((int)stream.Length) - i);
                        stream.Read(buffer, i, num2);
                    }
                }
            } catch (Exception) {
                UIConsole.Warn(string.Format("Cannot load {0} from library.", filename));
            }
            return buffer;
        }
    }
}
