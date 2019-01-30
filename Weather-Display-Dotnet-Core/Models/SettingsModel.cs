using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Display_Dotnet_Core.Models
{
    class SettingsModel
    {

        public static ObservableCollection<string> langInit()
        {
            // If there is a language missing here then please open a PR or an issue
            return new ObservableCollection<string>()
            {
                // Norwegian Bokmål has 2 bindings, nb and no. nb is used here
                //{"Arabic", "ar"},
                //{"Azerbaijani", "az"},
                //{"Belarusian", "be"},
                //{"Bulgarian", "bg"},
                //{"Bosnian", "bs"},
                //{"Catalan", "ca"},
                //{"Czech", "cs"},
                //{"Danish", "da"},
                //{"German", "de"},
                //{"Greek", "el"},
                //{"English", "en"},
                //{"Spanish", "es"},
                //{"Estonian", "et"},
                //{"Finnish", "fi"},
                //{"French", "fr"},
                //{"Hebrew", "he"},
                //{"Croatian", "hr"},
                //{"Hungarian", "hu"},
                //{"Indonesian", "id"},
                //{"Icelandic", "is"},
                //{"Italian", "it"},
                //{"Japanese", "ja"},
                //{"Georgian", "ka"},
                //{"Korean", "ko"},
                //{"Cornish", "kw"},
                //{"Latvian", "lv"},
                //{"Norwegian Bokmål", "nb"},
                //{"Dutch", "nl"},
                //{"Polish", "pl"},
                //{"Portuguese", "pt"},
                //{"Romanian", "ro"},
                //{"Russian", "ru"},
                //{"Slovak", "sk"},
                //{"Slovenian", "sl"},
                //{"Serbian", "sr"},
                //{"Swedish", "sv"},
                //{"Tetum", "tet"},
                //{"Turkish", "tr"},
                //{"Ukrainian", "uk"},
                //{"Igpay Atinlay", "x-pig-latin"},
                //{"Chinese (Simplified)", "zh"},
                //{"Chinese (Traditional)", "zh-tw"}
                // This was going to be different but I couldn't get it all working
                "ar",
                "az",
                "be",
                "bg",
                "bs",
                "ca",
                "cs",
                "da",
                "de",
                "el",
                "en",
                "es",
                "et",
                "fi",
                "fr",
                "he",
                "hr",
                "hu",
                "id",
                "is",
                "it",
                "ja",
                "ka",
                "ko",
                "kw",
                "lv",
                "nb",
                "nl",
                "pl",
                "pt",
                "ro",
                "ru",
                "sk",
                "sl",
                "sr",
                "sv",
                "tet",
                "tr",
                "uk",
                "x-pig-latin",
                "zh",
                "zh-tw"
            };
        }

        public static ObservableCollection<string> unitInit()
        {
            // If there is a unit missing here then please open a PR or an issue
            return new ObservableCollection<string>()
            {
                //{"Auto", "auto"},
                //{"Canadian", "ca"},
                //{"British", "uk2"},
                //{"American (Imperial)", "us"},
                //{"SI units", "si"},
                "auto",
                "ca",
                "uk2",
                "us",
                "si",
            };
        }

        public static ObservableCollection<string> summeryInit()
        {
            return new ObservableCollection<string>()
            {
                "Current",
                "Weeklong"
            };
        }

        public static async Task LoadSite(string siteToLoad)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = siteToLoad,
                    UseShellExecute = true
                };
                await Task.Run(() => Process.Start(psi));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                await Task.Run(() => Process.Start("open", siteToLoad));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Currently bugged when publishing from Visual Studio, use the dotnet publish command instead
                await Task.Run(() => Process.Start("xdg-open", siteToLoad));
            }
        }

    }
}
