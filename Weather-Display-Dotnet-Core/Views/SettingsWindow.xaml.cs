using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Weather_Display_Dotnet_Core.Views
{
    public class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            this.InitializeComponent();
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
