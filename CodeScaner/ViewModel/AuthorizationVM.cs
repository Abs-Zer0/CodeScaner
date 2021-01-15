using CodeScaner.Model;
using CodeScaner.Model.Settings;
using CodeScaner.Service;
using CodeScaner.View;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeScaner.ViewModel
{
    public class AuthorizationVM : INotifyPropertyChanged
    {
        private bool _isError = false;
        public bool IsError
        {
            get => this._isError;
            set
            {
                if (value != this._isError)
                {
                    this._isError = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsError)));
                }
            }
        }

        private string _errorMsg = "Ошибка";
        public string ErrorMsg
        {
            get => this._errorMsg;
            set
            {
                if (value != this._errorMsg)
                {
                    this._errorMsg = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorMsg)));
                }
            }
        }

        private string _login = "";
        public string Login
        {
            get => this._login;
            set
            {
                if (value != this._login)
                {
                    this._login = value.Length > Constants.SIGN_IN_LENGTH ?
                        value.Substring(0, Constants.SIGN_IN_LENGTH) : value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Login)));
                }
            }
        }

        private string _password = "";
        public string Password
        {
            get => this._password;
            set
            {
                if (value != this._password)
                {
                    this._password = value.Length > Constants.SIGN_IN_LENGTH ?
                        value.Substring(0, Constants.SIGN_IN_LENGTH) : value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }

        public ICommand Authorize { get; }

        public ICommand OpenSettings { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private INavigation navigation;

        public AuthorizationVM(INavigation navigationContext)
        {
            this.navigation = navigationContext;
            this.Authorize = new Command(Auth);
            this.OpenSettings = new Command(Settings);
        }

        private async void Auth()
        {
            try
            {
                await Services.Server.SignInAsync(this._login, this._password);

                //Services.Settings.AddOrUpdatePerson(new Person(this._login, this._password));
                Services.Settings.AddOrUpdatePerson(this._login, this._password);

                await this.navigation.PushAsync(new ScanSelectPage());
            }
            catch (Exception ex)
            {
                this.IsError = true;
                this.ErrorMsg = ex.Message;

                Timer t = new Timer((obj) => { this.IsError = false; }, null, Constants.DEFAULT_TIMEOUT, Timeout.Infinite);
            }
        }

        private async void Settings()
        {
            await this.navigation.PushAsync(new SettingsPage());
        }
    }
}
