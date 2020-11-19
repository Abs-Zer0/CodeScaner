using CodeScaner.Model;
using CodeScaner.ViewModel;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeScaner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServerChatPage : ContentPage
    {
        private TcpClient client = new TcpClient();
        private ServerChatVM chat = new ServerChatVM();

        public ServerChatPage()
        {
            InitializeComponent();
            this.BindingContext = chat;
            ClientConnect();
        }

        protected override void OnDisappearing()
        {
            client.Close();
            base.OnDisappearing();
        }

        private void ClientConnect()
        {
            string[] ipPort = CrossSettings.Current.GetValueOrDefault("ip:port", "0.0.0.0:0").Split(':');
            client.ConnectAsync(IPAddress.Parse(ipPort[0]), int.Parse(ipPort[1]));
        }

        private void Send(object sender, EventArgs e)
        {
            chat.Messages.Add(new TestMessage() { Text = chat.TextToSend, IsSelf = true });
            chat.TextToSend = string.Empty;
        }
    }
}