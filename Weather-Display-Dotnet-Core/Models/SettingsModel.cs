using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weather_Display_Dotnet_Core.Models
{
    class SettingsModel
    {

        public static Dictionary<string,string> langInit()
        {
            // If there is a language missing here then please open a PR or an issue
            return (Dictionary<string,string>)new Dictionary<string, string>()
            {
                // Norwegian Bokmål has 2 bindings, nb and no. nb is used here
                {"Arabic", "ar"},
                {"Azerbaijani", "az"},
                {"Belarusian", "be"},
                {"Bulgarian", "bg"},
                {"Bosnian", "bs"},
                {"Catalan", "ca"},
                {"Czech", "cs"},
                {"Danish", "da"},
                {"German", "de"},
                {"Greek", "el"},
                {"English", "en"},
                {"Spanish", "es"},
                {"Estonian", "et"},
                {"Finnish", "fi"},
                {"French", "fr"},
                {"Hebrew", "he"},
                {"Croatian", "hr"},
                {"Hungarian", "hu"},
                {"Indonesian", "id"},
                {"Icelandic", "is"},
                {"Italian", "it"},
                {"Japanese", "ja"},
                {"Georgian", "ka"},
                {"Korean", "ko"},
                {"Cornish", "kw"},
                {"Latvian", "lv"},
                {"Norwegian Bokmål", "nb"},
                {"Dutch", "nl"},
                {"Polish", "pl"},
                {"Portuguese", "pt"},
                {"Romanian", "ro"},
                {"Russian", "ru"},
                {"Slovak", "sk"},
                {"Slovenian", "sl"},
                {"Serbian", "sr"},
                {"Swedish", "sv"},
                {"Tetum", "tet"},
                {"Turkish", "tr"},
                {"Ukrainian", "uk"},
                {"Igpay Atinlay", "x-pig-latin"},
                {"Chinese (Simplified)", "zh"},
                {"Chinese (Traditional)", "zh-tw"}
            }.OrderBy(i => i.Key);
            // Why programmically order instead of ordering this list in code?
            // This list is taken from the Darksky API Docs, any missing languages can easily be added back in
            // But the displayed list should be in a good order so that it can actually be used
        }

        public static Dictionary<string, string> unitInit()
        {
            // If there is a unit missing here then please open a PR or an issue
            return new Dictionary<string, string>()
            {
                {"Auto", "auto"},
                {"Canadian", "ca"},
                {"British", "uk2"},
                {"American (Imperial)", "us"},
                {"SI units", "si"},
            };
        }

    }
}
