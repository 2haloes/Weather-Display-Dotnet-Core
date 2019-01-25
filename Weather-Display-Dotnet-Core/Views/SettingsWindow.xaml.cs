using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Weather_Display_Dotnet_Core.Models;

namespace Weather_Display_Dotnet_Core.Views
{
    public class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            ViewModels.SettingsViewModel settingsViewModel = new ViewModels.SettingsViewModel();

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
