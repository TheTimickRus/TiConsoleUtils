using Spectre.Console.Cli;
using TiConsoleUtils.SystemInfo.Commands;

namespace TiConsoleUtils.SystemInfo
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var app = new CommandApp();
            
            app.Configure(
                configurator =>
                {
                    configurator.Settings.ApplicationName = "TiConsoleUtils.SystemInfo";
                    configurator.Settings.ApplicationVersion = "1.1,";

                    configurator.AddCommand<DxDiagCommand>("dxdiag");
                });
            
            app.Run(args);
        }
    }
}