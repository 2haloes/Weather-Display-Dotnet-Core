using Avalonia;
using Avalonia.Markup.Xaml;

namespace Weather_Display_Dotnet_Core
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
