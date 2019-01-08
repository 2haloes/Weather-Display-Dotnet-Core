using System;
using System.Collections.Generic;
using System.Text;

namespace Weather_Display_Dotnet_Core.Models
{
    class Settings
    {
        private bool _fullScreen;
        private string _apiKey;
        private double _lat;
        private double _lon;

        public bool fullScreen { get => _fullScreen; set => _fullScreen = value; }
        public string apiKey { get => _apiKey; set => _apiKey = value; }
        public double lat { get => _lat; set => _lat = value; }
        public double lon { get => _lon; set => _lon = value; }
    }
}
