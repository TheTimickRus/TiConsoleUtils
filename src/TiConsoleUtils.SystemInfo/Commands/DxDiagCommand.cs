// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System;
using System.ComponentModel;
using System.Threading;
using Spectre.Console;
using Spectre.Console.Cli;
using TiConsoleUtils.SystemInfo.Backend.DxDiag;
using TiConsoleUtils.SystemInfo.Backend.SendMessages;

namespace TiConsoleUtils.SystemInfo.Commands
{
    public class DxDiagCommand : Command<DxDiagCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandArgument(0, "<email>")]
            public string Email { get; set; }
            
            [CommandOption("-f|--filename")]
            [DefaultValue("dxdiag.log")]
            public string FileName { get; init; }
        }

        public override int Execute(CommandContext context, Settings settings)
        {
            Console.Title = "TiConsoleUtils.SystemInfo - DxDiagCommand";
            
            Print("Please wait...", Color.Blue);
            
            if (DxDiagMain.CreateDxDiagFile(settings.FileName) && SendEmail.SendMessage(settings.Email, settings.FileName))
            {
                Print("Done!", Color.Green);
                return 0;
            }

            Print("Fail...", Color.Red);
            return 1;
        }

        private static void Print(string msg, Color color)
        {
            Console.Clear();
            AnsiConsole.Render(new FigletText(msg).Color(color));
            Thread.Sleep(2000);
        }
    }
}