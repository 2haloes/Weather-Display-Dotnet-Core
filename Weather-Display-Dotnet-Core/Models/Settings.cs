using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Weather_Display_Dotnet_Core.Models
{
    public class Settings
    {
        private bool _fullScreen;
        private string _apiKey;
        private double _lat;
        private double _lon;
        private string _units;
        private int _minCheck;
        private string _lang;
        private string _summeryType;

        public bool fullScreen { get => _fullScreen; set => _fullScreen = value; }
        public string apiKey { get => _apiKey; set => _apiKey = value; }
        public double lat { get => _lat; set => _lat = value; }
        public double lon { get => _lon; set => _lon = value; }
        public string units { get => _units; set => _units = value; }
        public int minCheck { get => _minCheck; set => _minCheck = value; }
        public string lang { get => _lang; set => _lang = value; }
        [DefaultValue("Current")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string summeryType { get => _summeryType; set => _summeryType = value; }
    }
}
