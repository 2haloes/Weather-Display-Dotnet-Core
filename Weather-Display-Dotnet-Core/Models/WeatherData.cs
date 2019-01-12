using Avalonia.Media.Imaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Weather_Display_Dotnet_Core.Models
{
    public class WeatherData
    {
        /// <summary>
        /// The data for the current moment
        /// </summary>
        public class RightNow
        {
            private string _summary;
            private string _icon;
            private double _temperature;
            private string _temperatureDisplay;

            public string summary { get => _summary; set => _summary = value; }
            public string icon { get => _icon; set => _icon = value; }
            public double temperature { get => _temperature; set => _temperature = value; }
            // Values generated based on the JSON data
            [JsonIgnore]
            public IBitmap iconBitmap { get => new Bitmap("images/" + _icon + ".png"); }
            [JsonIgnore]
            public string temperatureDisplay { get => _temperatureDisplay; set => _temperatureDisplay = value; }
        }
        /// <summary>
        /// The summary for the week as well as collecting all of the
        /// data for each day for the next 5 days
        /// </summary>
        public class ByDay
        {
            public ByDay()
            {
                data = new ObservableCollection<DayData>();
            }

            private string _summary;
            private ObservableCollection<DayData> _data;

            public string summary { get => _summary; set => _summary = value; }
            public ObservableCollection<DayData> data { get => _data; set => _data = value; }
        }
        /// <summary>
        /// All of the data for that day
        /// </summary>
        public class DayData
        {
            private string _summary;
            private string _icon;
            private long _time;
            private double _temperatureMin;
            private double _temperatureMax;
            private long _sunriseTime;
            private long _sunsetTime;
            private string _temperatureMinDisplay;
            private string _temperatureMaxDisplay;

            public string summary { get => _summary; set => _summary = value; }
            public string icon { get => _icon; set => _icon = value; }
            public long time { get => _time; set => _time = value; }
            public double temperatureMin { get => _temperatureMin; set => _temperatureMin = value; }
            public double temperatureMax { get => _temperatureMax; set => _temperatureMax = value; }
            public long sunriseTime { get => _sunriseTime; set => _sunriseTime = value; }
            public long sunsetTime { get => _sunsetTime; set => _sunsetTime = value; }
            // Generated values based on the JSON
            [JsonIgnore]
            public IBitmap iconData { get => new Bitmap("images/" + _icon + ".png"); }
            [JsonIgnore]
            public string dayDisplay { get => FromUnix(time).ToString("ddd"); }
            [JsonIgnore]
            public string sunriseTimeDisplay { get => FromUnix(sunriseTime).ToShortTimeString(); }
            [JsonIgnore]
            public string sunsetTimeDisplay { get => FromUnix(sunsetTime).ToShortTimeString(); }
            [JsonIgnore]
            public string temperatureMinDisplay { get => _temperatureMinDisplay; set => _temperatureMinDisplay = value; }
            [JsonIgnore]
            public string temperatureMaxDisplay { get => _temperatureMaxDisplay; set => _temperatureMaxDisplay = value; }
        }
        public class FlagsData
        {
            private string _units;

            public string units { get => _units; set => _units = value; }
        }
        /// <summary>
        /// Converts a long to a date
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public static DateTime FromUnix(long Time)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(Time).ToLocalTime();
        }
        /// <summary>
        /// All of the data collected together
        /// </summary>
        public class WeatherReport
        {
            public WeatherReport()
            {
                flags = new FlagsData();
                currently = new RightNow();
                daily = new ByDay();
            }

            private RightNow _currently;
            private ByDay _daily;
            private FlagsData _flags;

            public RightNow currently { get => _currently; set => _currently = value; }
            public ByDay daily { get => _daily; set => _daily = value; }
            public FlagsData flags { get => _flags; set => _flags = value; }
        }
    }
}
