using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Weather_Display_Dotnet_Core.Models;

namespace Weather_Display_Dotnet_Core.ViewModels
{
    class SettingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public SettingsViewModel(Action saveAction)
        {
            initSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "settings.json"));
            LangList = SettingsModel.langInit();
            UnitList = SettingsModel.unitInit();
            SummeryList = SettingsModel.summeryInit();
            SaveComand = new DelegateCommand(() => SaveSettings());
            ApiLoadCommand = new DelegateCommand(async () => await ApiLoadAsync());
            LatLongCommand = new DelegateCommand(async () => await LatLongAsync());
            SaveText = "Save";
            SaveAction = saveAction;
        }

        private Models.Settings _initSettings;
        ObservableCollection<string> _langList;
        ObservableCollection<string> _unitList;
        ObservableCollection<string> _summeryList;
        private DelegateCommand _closeWindowComand;
        private DelegateCommand _apiLoadCommand;
        private DelegateCommand _latLongCommand;
        private string _saveText;
        private Action _saveAction;

        public Models.Settings initSettings { get => _initSettings; set => _initSettings = value; }
        public ObservableCollection<string> LangList { get => _langList; set => _langList = value; }
        public ObservableCollection<string> UnitList { get => _unitList; set => _unitList = value; }
        public ObservableCollection<string> SummeryList { get => _summeryList; set => _summeryList = value; }
        public DelegateCommand SaveComand { get => _closeWindowComand; set => _closeWindowComand = value; }
        public DelegateCommand ApiLoadCommand { get => _apiLoadCommand; set => _apiLoadCommand = value; }
        public DelegateCommand LatLongCommand { get => _latLongCommand; set => _latLongCommand = value; }
        public string SaveText { get => _saveText; set => SetField(ref _saveText, value); }
        public Action SaveAction { get => _saveAction; set => _saveAction = value; }


        private void SaveSettings()
        {
            SaveText = "Saving";
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "settings.json", JsonConvert.SerializeObject(initSettings));
            SaveAction.Invoke();
            SaveText = "Successfully saved!";
        }

        private async Task ApiLoadAsync()
        {
            await SettingsModel.LoadSite("https://darksky.net/dev/account");
        }

        private async Task LatLongAsync()
        {
            await SettingsModel.LoadSite("https://www.latlong.net");
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
