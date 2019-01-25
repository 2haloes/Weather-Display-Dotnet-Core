using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Weather_Display_Dotnet_Core.Models;

namespace Weather_Display_Dotnet_Core.ViewModels
{
    class SettingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public SettingsViewModel()
        {
            initSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "settings.json"));
            LangList = SettingsModel.langInit();
            UnitList = SettingsModel.unitInit();
        }

        private Models.Settings _initSettings;
        ObservableCollection<string> _langList;
        ObservableCollection<string> _unitList;
        private DelegateCommand<ICloseWin> _closeWindowComand;

        public Models.Settings initSettings { get => _initSettings; set => _initSettings = value; }
        public ObservableCollection<string> LangList { get => _langList; set => _langList = value; }
        public ObservableCollection<string> UnitList { get => _unitList; set => _unitList = value; }
        public DelegateCommand<ICloseWin> CloseWindowComand { get => _closeWindowComand; set => _closeWindowComand = value; }


        private void CloseWindow(ICloseWin window)
        {
            if (window != null)
            {
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "settings.json", JsonConvert.SerializeObject(initSettings));
                window.Close();
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
