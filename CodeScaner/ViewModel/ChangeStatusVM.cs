using CodeScaner.Model;
using CodeScaner.Service;
using CodeScaner.View;
using sbc.data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
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

        private string _successMsg = "Успешно";
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

        public ObservableCollection<string> Statuses { get; } = new ObservableCollection<string>(new[]
        {
            "В обработке", "Отправлено", "В пути", "Получено", "Потеряно", "Другое:"
        });

        private string _status = "";
        public string SelectedStatus
        {
            get => this._status;
            set
            {
                if (value != this._status)
                {
                    this._status = value;
                    this.IsOther = statusValues[value] == Status.Other;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedStatus)));
                }
            }
        }

        private bool _isOther = false;
        public bool IsOther
        {
            get => this._isOther;
            private set
            {
                if (value != this._isOther)
                {
                    this._isOther = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(IsOther)));
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
                    this._otherText = value.Length > Constants.DESCRIPTION_LENGTH ?
                        value.Substring(0, Constants.DESCRIPTION_LENGTH) : value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(OtherText)));
                }
            }
        }

        public ICommand Send { get; }

        public ICommand OpenSettings { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private INavigation navigation;

        private Dictionary<string, Status> statusValues = new Dictionary<string, Status>()
        {
            { "В обработке", Status.Processing }, { "Отправлено", Status.Send },
            { "В пути", Status.Travel }, { "Получено", Status.Receive },
            { "Потеряно", Status.Lost }, { "Другое:", Status.Other }
        };

        public ChangeStatusVM(INavigation navigationContext, string barcode = "")
        {
            this.navigation = navigationContext;
            this._barcode = barcode;
            this._status = Statuses[0];
            this.Send = new Command(SendData);
            this.OpenSettings = new Command(Settings);
        }

        private async void SendData()
        {
            try
            {
                string description = this.statusValues[this._status] == Status.Other ? this._otherText : "";
                await Services.Server.ChangeStatusAsync(this._barcode, this.statusValues[this._status], description);

                this.IsSuccess = true;
                this.SuccessMsg = "Статус успешно изменён";

                Timer t = new Timer((obj) => { this.IsSuccess = false; }, null, Constants.DEFAULT_TIMEOUT, Timeout.Infinite);
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
