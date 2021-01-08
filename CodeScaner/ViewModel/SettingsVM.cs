using Plugin.Settings;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeScaner.ViewModel
{
    public class SettingsVM : INotifyPropertyChanged
    {
        private string _ip = "0.0.0.0";
        public string IP
        {
            get => this._ip;
            set
            {
                if (value != this._ip)
                {
                    this._ip = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IP)));

                    /*if (ipMatch.IsMatch(value))
                    {
                        this._ip = value;
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IP)));
                    }*/
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
                    catch (Exception) {
                        this._port = 0.ToString();
                    }

                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Port)));
                }
            }
        }

        public ICommand SaveSettings { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Regex ipMatch;

        public SettingsVM()
        {
            this.ipMatch = new Regex(@"^(25[0-5]|2[0-4][0-9]|[0-1][0-9]{2}|[0-9]{2}|[0-9])(\.(25[0-5]|2[0-4][0-9]|[0-1][0-9]{2}|[0-9]{2}|[0-9])){3}$");
            this.SaveSettings = new Command(Save);
            Load();
        }

        private void Load()
        {
            string ipPort = CrossSettings.Current.GetValueOrDefault("ip:port", "0.0.0.0:0");
            string[] splitted = ipPort.Split(':');
            this._ip = splitted[0];
            this._port = splitted[1];
        }

        private void Save()
        {
            CrossSettings.Current.AddOrUpdateValue("ip:port", this._ip + ":" + this._port);
        }
    }
}
