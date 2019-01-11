﻿using Avalonia.Controls;
using Weather_Display_Dotnet_Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;

namespace Weather_Display_Dotnet_Core.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            CurrentTime = DateTime.Now.ToString("hh:mmtt");
            SetTimer();
            websiteClient = new HttpClient();
        }

        private HttpClient _websiteClient;
        private int _cycleCheck;
        private Settings _programSettings;
        private WeatherData.WeatherReport _weatherData;
        private string _currentTime;
        private Timer _cycleTimer;

        public HttpClient websiteClient { get => _websiteClient; set => SetField(ref _websiteClient, value); }
        public int cycleCheck { get => _cycleCheck; set => SetField(ref _cycleCheck, value); }
        public Settings programSettings { get => _programSettings; set => SetField(ref _programSettings, value); }
        public WeatherData.WeatherReport WeatherData { get => _weatherData; set => SetField(ref _weatherData, value); }
        public string CurrentTime { get => _currentTime; set => SetField(ref _currentTime, value); }
        public Timer cycleTimer { get => _cycleTimer; set => SetField(ref _cycleTimer, value); }


        private async void TimerTrigger(object source, ElapsedEventArgs e)
        {
            // TODO: After implimenting settings, change the number to programSettings.minCheck*12 (minCheck being the minutes between loading the weather data)
            if (cycleCheck >= 24)
            {
                cycleCheck = 0;

                HttpResponseMessage response = await websiteClient.GetAsync(String.Format("https://api.darksky.net/forecast/{0}/{1},{2}?units={3}&lang={4}",
                    programSettings.apiKey, programSettings.lat, programSettings.lon, programSettings.units, programSettings.lang));

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    List<string> logContent = new List<string>();
                    if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy-MM-dd") + "_errorLog.txt"))
                    {
                        logContent = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy-MM-dd") + "_errorLog.txt").ToList();
                    }
                    logContent.Add(DateTime.Now.ToLongTimeString() + ": " + ex.Message);
                    File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy-MM-dd") + "_errorLog.txt", logContent);
                    return;
                }

                WeatherData = JsonConvert.DeserializeObject<WeatherData.WeatherReport>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                // TODO: Possibly change CurrentTime to a getter and just update it here
                CurrentTime = DateTime.Now.ToString("hh:mmtt");
                cycleCheck++;
            }
            return;
        }

        private void SetTimer()
        {
            // Cycle timer checks the time every 5 seconds. 
            // The weather is updated based on the cycleCheck if statement in the TimerTrigger method (Orginally
            cycleTimer = new Timer(5000);
            cycleTimer.Elapsed += TimerTrigger;
            cycleTimer.AutoReset = true;
            cycleTimer.Enabled = true;
        }


        #region PropertyChanged code
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
