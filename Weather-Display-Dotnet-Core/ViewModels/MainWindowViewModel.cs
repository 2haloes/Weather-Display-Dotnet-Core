using Avalonia.Controls;
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
using Avalonia.Media.Imaging;
using Prism.Commands;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Weather_Display_Dotnet_Core.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            CurrentTime = DateTime.Now.ToString("hh:mmtt");
            SetTimer();
            websiteClient = new HttpClient();
            programSettings = MainWindowModel.LoadSettings();
            LoadSettingsWindow = new DelegateCommand(async () => await OpenSettingsWindow());
            LoadDarkSkyWebsite = new DelegateCommand(async () => await LoadWebsite());
            cycleCheck = (programSettings.minCheck * 12);
            TimerTrigger(null, null);
        }

        private HttpClient _websiteClient;
        private int _cycleCheck;
        private Settings _programSettings;
        private WeatherData.WeatherReport _weatherDisplay;
        private string _currentTime;
        private Timer _cycleTimer;
        private DelegateCommand _loadSettingsWindow;
        private DelegateCommand _loadDarkSkyWebsite;

        public DelegateCommand LoadSettingsWindow { get => _loadSettingsWindow; set => SetField(ref _loadSettingsWindow, value); }
        public DelegateCommand LoadDarkSkyWebsite { get => _loadDarkSkyWebsite; set => SetField(ref _loadDarkSkyWebsite, value); }
        public HttpClient websiteClient { get => _websiteClient; set => SetField(ref _websiteClient, value); }
        public IBitmap DefaultIcon { get => new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "images/clear-day.png"); }
        public IBitmap SunRiseBitmap { get => new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "images/sun-rise.png"); }
        public IBitmap SunSetBitmap { get => new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "images/sun-set.png"); }
        public int cycleCheck { get => _cycleCheck; set => SetField(ref _cycleCheck, value); }
        public Settings programSettings { get => _programSettings; set => SetField(ref _programSettings, value); }
        public WeatherData.WeatherReport WeatherDisplay { get => _weatherDisplay; set => SetField(ref _weatherDisplay, value); }
        public string CurrentTime { get => _currentTime; set => SetField(ref _currentTime, value); }
        public string SummeryDisplay { get => SummerySetup(); }
        public Timer cycleTimer { get => _cycleTimer; set => SetField(ref _cycleTimer, value); }


        private async void TimerTrigger(object source, ElapsedEventArgs e)
        {
            // TODO: After implimenting settings, change the number to programSettings.minCheck*12 (minCheck being the minutes between loading the weather data)
            if (cycleCheck < (programSettings.minCheck * 12))
            {
                // TODO: Possibly change CurrentTime to a getter and just update it here
                CurrentTime = DateTime.Now.ToString("hh:mmtt");
                cycleCheck++;
            }
            else
            {
                cycleCheck = 0;
                WeatherData.WeatherReport WeatherData;

                try
                {
                    HttpResponseMessage response = await websiteClient.GetAsync(String.Format("https://api.darksky.net/forecast/{0}/{1},{2}?units={3}&lang={4}&exclude={5}",
                    programSettings.apiKey, programSettings.lat, programSettings.lon, programSettings.units, programSettings.lang, "minutely,hourly"));

                    response.EnsureSuccessStatusCode();

                    WeatherData = JsonConvert.DeserializeObject<WeatherData.WeatherReport>(await response.Content.ReadAsStringAsync());

                    WeatherDisplay = await MainWindowModel.SetTempDisplayAsync(WeatherData);
                    OnPropertyChanged("SummeryDisplay");
                }
                catch (Exception ex)
                {
                    await MainWindowModel.ErrorReportAsync(ex.Message);
                    return;
                }
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

        private async Task OpenSettingsWindow()
        {
            Views.SettingsWindow settingsWin = new Views.SettingsWindow(SettingsUpdate);
            settingsWin.Show();
            programSettings = MainWindowModel.LoadSettings();
        }

        private void SettingsUpdate()
        {
            programSettings = MainWindowModel.LoadSettings();
            OnPropertyChanged("SummeryDisplay");
        }

        private async Task LoadWebsite()
        {
            string darkSkySite = "https://darksky.net/poweredby/";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = darkSkySite,
                    UseShellExecute = true
                };
                await Task.Run(() => Process.Start(psi));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                await Task.Run(() => Process.Start("open", darkSkySite));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Currently bugged when publishing from Visual Studio, use the dotnet publish command instead
                await Task.Run(() => Process.Start("xdg-open", darkSkySite));
            }
        }

        private string SummerySetup()
        {
            if (WeatherDisplay != null)
            {
                return (programSettings.summeryType == "Current") ? _weatherDisplay.currently.summary : _weatherDisplay.daily.summary;
            }
            else
            {
                return null;
            }
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
