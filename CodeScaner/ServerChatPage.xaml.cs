using CodeScaner.Model;
using CodeScaner.ViewModel;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeScaner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServerChatPage : ContentPage
    {
        private ServerChatVM chat = new ServerChatVM();

        public ServerChatPage()
        {
            InitializeComponent();
            this.BindingContext = chat;
        }

        protected override void OnDisappearing()
        {
            chat.Client.Close();
            base.OnDisappearing();
        }
    }
}