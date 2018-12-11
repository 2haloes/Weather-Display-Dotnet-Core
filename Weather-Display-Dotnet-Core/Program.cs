using System;
using Avalonia;
using Avalonia.Logging.Serilog;
using Weather_Display_Dotnet_Core.ViewModels;
using Weather_Display_Dotnet_Core.Views;

namespace Weather_Display_Dotnet_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildAvaloniaApp().Start<MainWindow>(() => new MainWindowViewModel());
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .LogToDebug();
    }
}
