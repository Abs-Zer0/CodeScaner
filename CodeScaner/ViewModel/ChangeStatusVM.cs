using CodeScaner.View;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeScaner.ViewModel
{
    public class ChangeStatusVM : INotifyPropertyChanged
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

        private string _successMsg = "Ошибка";
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

        private string _barcode = "";
        public string Barcode
        {
            get => this._barcode;
            set
            {
                if (value != this._barcode)
                {
                    this._barcode = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Barcode)));
                }
            }
        }

        private string _status = "";
        public string Status
        {
            get => this._status;
            set
            {
                if (value != this._status)
                {
                    this._status = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
                }
            }
        }

        private string _otherText = "";
        public string OtherText
        {
            get => this._otherText;
            set
            {
                if (value != this._otherText)
                {
                    this._otherText = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherText)));
                }
            }
        }

        public ICommand Send { get; }

        public ICommand OpenSettings { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private INavigation navigation;

        public ChangeStatusVM(INavigation navigationContext, string barcode = "")
        {
            this.navigation = navigationContext;
            this._barcode = barcode;
            this.Send = new Command(SendData);
            this.OpenSettings = new Command(Settings);
        }

        private void SendData()
        {

        }

        private async void Settings()
        {
            await this.navigation.PushAsync(new SettingsPage());
        }
    }
}
