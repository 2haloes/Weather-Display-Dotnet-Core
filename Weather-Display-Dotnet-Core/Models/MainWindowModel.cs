using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Display_Dotnet_Core.Models
{
    class MainWindowModel
    {
        /// <summary>
        /// If there is an error downloading the JSON data, this will log it into the program folder
        /// </summary>
        /// <param name="reportString"></param>
        /// <returns></returns>
        public static async Task ErrorReportAsync(string reportString)
        {
            List<string> logContent = new List<string>();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy-MM-dd") + "_errorLog.txt"))
            {
                logContent = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy-MM-dd") + "_errorLog.txt").ToList();
            }
            logContent.Add(DateTime.Now.ToLongTimeString() + ": " + reportString);
            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy-MM-dd") + "_errorLog.txt", logContent);
        }

        /// <summary>
        /// The units value is away from the currently and daily values so this sets the string to display 
        /// (This can be changed to work with wind speeds as well)
        /// </summary>
        /// <param name="weatherData"></param>
        /// <returns></returns>
        public static Task<WeatherData.WeatherReport> SetTempDisplayAsync(WeatherData.WeatherReport weatherData)
        {
            // Why not just have this set up as a getter? Well I couldn't figure out how to pass the value from flags to the other classes
            string tempExt = (weatherData.flags.units == "us") ? "°F" : "°C";
            int decimalPlaces = (weatherData.flags.units == "us") ? 0 : 1;

            weatherData.currently.temperatureDisplay = weatherData.currently.temperature.ToString("F" + decimalPlaces) + tempExt;

            for (int i = 0; i < weatherData.daily.data.Count; i++)
            {
                weatherData.daily.data[i].temperatureMaxDisplay = weatherData.daily.data[i].temperatureMax.ToString("F" + decimalPlaces) + tempExt;
                weatherData.daily.data[i].temperatureMinDisplay = weatherData.daily.data[i].temperatureMin.ToString("F" + decimalPlaces) + tempExt;
            }

            return Task.FromResult(weatherData);
        }

    }
}
