using Plugin.Settings;
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
                    if (ipMatch.IsMatch(value))
                    {
                        this._ip = value;
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IP)));
                    }
                }
            }
        }

        private string _port = "0";
        public string Port
        {
            get => this._port;
            set
            {
                if (value != this._port)
                {
                    if (portMatch.IsMatch(value))
                    {
                        this._port = value;
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Port)));
                    }
                }
            }
        }

        public ICommand SaveSettings { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly Regex ipMatch;
        private readonly Regex portMatch;

        public SettingsVM()
        {
            this.ipMatch = new Regex(@"^(25[0-5]|2[0-4][0-9]|[0-1][0-9]{2}|[0-9]{2}|[0-9])(\.(25[0-5]|2[0-4][0-9]|[0-1][0-9]{2}|[0-9]{2}|[0-9])){3}$");
            this.portMatch = new Regex(@"^(([0-9]{1,4})|([1-5][0-9]{4})|(6[0-4][0-9]{3})|(65[0-4][0-9]{2})|(655[0-2][0-9])|(6553[0-5]))$");
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
