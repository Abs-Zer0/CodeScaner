using CodeScaner.View;
using System.ComponentModel;
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
                    this._login = value;
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
                    this._password = value;
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
            await this.navigation.PushAsync(new ScanSelectPage());
        }

        private async void Settings()
        {
            await this.navigation.PushAsync(new SettingsPage());
        }
    }
}
