using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Weather_Display_Dotnet_Core.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            // Could not get this to work using XAML (Would crash and report an issue relating to not being able to get a static member)
            this.Height = Screens.Primary.Bounds.Height;
            this.Width = Screens.Primary.Bounds.Width;
        }
    }
}
