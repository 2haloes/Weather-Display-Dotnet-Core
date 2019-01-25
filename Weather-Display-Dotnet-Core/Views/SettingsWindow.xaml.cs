using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Weather_Display_Dotnet_Core.Models;

namespace Weather_Display_Dotnet_Core.Views
{
    public class SettingsWindow : Window
    {
        public SettingsWindow(Action saveAction)
        {
            ViewModels.SettingsViewModel settingsViewModel = new ViewModels.SettingsViewModel(saveAction);

            this.InitializeComponent();

            this.DataContext = settingsViewModel;
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
