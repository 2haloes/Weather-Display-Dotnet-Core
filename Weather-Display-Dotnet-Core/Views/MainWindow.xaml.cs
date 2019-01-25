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

            // This is here because it is impossible to get the screen resolution otherwise.
            // If the screen resolution can be found from the ViewModel or have a variable passed to it then please inform me
            if (System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "settings.json"))
            {
                Models.Settings initSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Settings>(System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "settings.json"));
                if (initSettings.fullScreen)
                {
                    
                    WindowState = WindowState.Maximized;
                    ClientSize = new Size(Screens.Primary.Bounds.Width, Screens.Primary.Bounds.Height);
                    HasSystemDecorations = false;
                    
                }
            }
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
