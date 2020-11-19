using CodeScaner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeScaner.ViewModel
{
    public class ServerChatVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TestMessage> Messages { get; set; } = new ObservableCollection<TestMessage>();
        private string txt = "";
        public string TextToSend
        {
            get => txt;
            set
            {
                if (!txt.Equals(value))
                {
                    txt = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(TextToSend)));
                }
            }
        }

        public ServerChatVM()
        {

        }
    }
}
