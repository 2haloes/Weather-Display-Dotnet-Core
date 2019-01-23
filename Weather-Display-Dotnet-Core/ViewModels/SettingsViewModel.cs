using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Weather_Display_Dotnet_Core.ViewModels
{
    class SettingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public SettingsViewModel()
        {
            initSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Settings>(System.AppDomain.CurrentDomain.BaseDirectory + "settings.json");
        }

        private Models.Settings _initSettings;

        public Models.Settings initSettings { get => _initSettings; set => _initSettings = value; }





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
