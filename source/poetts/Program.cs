using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

// only works on windows
[assembly: SupportedOSPlatform("windows")]

namespace poetts
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // fix blurriness
            if (Environment.OSVersion.Version.Major >= 6)
            {
                User32.SetProcessDpiAware();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gui());
        }
    }
}
