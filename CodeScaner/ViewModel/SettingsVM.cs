using CodeScaner.Model;
using CodeScaner.Model.Settings;
using CodeScaner.Service;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;

namespace CodeScaner.ViewModel
{
    public class SettingsVM : INotifyPropertyChanged
    {
        private bool _isSuccess = false;
        public bool IsSuccess
        {
            get => this._isSuccess;
            set
            {
                if (value != this._isSuccess)
                {
                    this._isSuccess = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsSuccess)));
                }
            }
        }

        private string _successMsg = "Сохранено";
        public string SuccessMsg
        {
            get => this._successMsg;
            set
            {
                if (value != this._successMsg)
                {
                    this._successMsg = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SuccessMsg)));
                }
            }
        }

        private string _url = "0.0.0.0";
        public string Url
        {
            get => this._url;
            set
            {
                if (value != this._url)
                {
                    this._url = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Url)));
                }
            }
        }

        private string _port = 0.ToString();
        public string Port
        {
            get => this._port;
            set
            {
                if (value != this._port)
                {
                    try
                    {
                        int val = int.Parse(value);
                        val = val < 0 ? 0 : val;
                        val = val > ushort.MaxValue ? ushort.MaxValue : val;

                        this._port = val.ToString();
                    }
                    catch (Exception)
                    {
                        this._port = 0.ToString();
                    }

                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Port)));
                }
            }
        }

        public ObservableCollection<BarcodeType> Formats { get; set; } = new ObservableCollection<BarcodeType>(BarcodeType.AllCodes);

        public ICommand SaveSettings { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public SettingsVM()
        {
            this.SaveSettings = new Command(Save);
            Load();
        }

        private void Load()
        {
            //var urlPort = Services.Settings.GetUrlPort(new ServerUrl());
            var urlPort = Services.Settings.GetUrlPort("0.0.0.0", "0");
            //this._url = urlPort.Url;
            this._url = urlPort[0];
            //this._port = urlPort.Port;
            this._port = urlPort[1];

            this.Formats = new ObservableCollection<BarcodeType>(Services.Settings.GetFormats(this.Formats));
        }

        private void Save()
        {
            //Services.Settings.AddOrUpdateUrlPort(new ServerUrl(this._url, this._port));
            Services.Settings.AddOrUpdateUrlPort(this._url, this._port);

            Services.Settings.AddOrUpdateFormats(this.Formats);

            this.IsSuccess = true;
            this.SuccessMsg = "Сохранено";
            Timer t = new Timer((obj) => { this.IsSuccess = false; }, null, Constants.DEFAULT_TIMEOUT, Timeout.Infinite);
        }
    }
}
