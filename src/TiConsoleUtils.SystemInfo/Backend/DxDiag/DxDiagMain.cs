using System.Diagnostics;
using System.IO;

namespace TiConsoleUtils.SystemInfo.Backend.DxDiag
{
    public static class DxDiagMain
    {
        private const string DxDiag = "dxdiag.exe /whql:off /t";

        public static bool CreateDxDiagFile(string filename)
        {
            var process = Process.Start("cmd", $"/c {DxDiag} {filename}");
            process?.WaitForExit();

            return File.Exists(filename);
        }
    }
}