using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;

namespace Weather_Display_Dotnet_Core.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            CurrentTime = DateTime.Now.ToLongTimeString();
            SetTimer();
        }

        private string _currentTime;
        private int _cycleCheck;
        private Models.Settings _programSettings;
        private Models.WeatherData.WeatherReport _weatherData;
        private Timer _cycleTimer;

        public string CurrentTime { get => _currentTime; set => SetField(ref _currentTime, value); }
        public int cycleCheck { get => _cycleCheck; set => SetField(ref _cycleCheck, value); }
        public Models.Settings programSettings { get => _programSettings; set => SetField(ref _programSettings, value); }
        public Models.WeatherData.WeatherReport WeatherData { get => _weatherData; set => SetField(ref _weatherData, value); }
        //public string CurrentTimeDisplay { get => CurrentTime.ToLongTimeString(); }
        public Timer cycleTimer { get => _cycleTimer; set => SetField(ref _cycleTimer, value); }


        private async void TimerTrigger(object source, ElapsedEventArgs e)
        {
            // TODO: After implimenting settings, change the number to programSettings.minCheck*12 (minCheck being the minutes between loading the weather data)
            if (cycleCheck >= 24)
            {
                cycleCheck = 0;
            }
            else
            {
                CurrentTime = DateTime.Now.ToShortTimeString();
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
