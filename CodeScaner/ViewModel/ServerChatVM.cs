using CodeScaner.Model;
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace CodeScaner.ViewModel
{
    public class ServerChatVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TestMessage> Messages { get; set; } = new ObservableCollection<TestMessage>();
        private string msg = "";
        public string MessageToSend
        {
            get => msg;
            set
            {
                if (msg != value)
                {
                    msg = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(MessageToSend)));
                }
            }
        }
        private string status = "";
        public string ConnectionStatus
        {
            get => status;
            set
            {
                if (status != value)
                {
                    status = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ConnectionStatus)));
                }
            }
        }

        public ICommand Send { get; set; }

        public TcpClient Client { get; private set; } = new TcpClient();

        public ServerChatVM()
        {
            Send = new Command(() => SendCommand());
            Connect();
        }

        private void Connect()
        {
            string[] ipPort = CrossSettings.Current.GetValueOrDefault("ip:port", "0.0.0.0:0").Split(':');
            ConnectionStatus = "Подключение к " + ipPort[0] + ":" + ipPort[1];
            Thread thr = new Thread(() =>
            {
                try
                {
                    IAsyncResult res = Client.BeginConnect(IPAddress.Parse(ipPort[0]),
                        int.Parse(ipPort[1]),
                        new AsyncCallback(ConnectionComplete),
                        ipPort);
                    Timer timer = new Timer(new TimerCallback(ConnectionCancel), res, 5000, Timeout.Infinite);
                }
                catch (Exception) { }
            });
        }

        private void ConnectionComplete(object obj)
        {
            string[] ipPort = (string[])obj;
            ConnectionStatus = "Подключено к " + ipPort[0] + ":" + ipPort[1];
            Thread thr = new Thread(() =>
              {
                  while (Client.Connected)
                  {
                      if (Client.Available > 0)
                      {
                          byte[] buf = new byte[Client.Available];
                          Client.GetStream().Read(buf, 0, buf.Length);
                          Messages.Add(new TestMessage(System.Text.Encoding.Unicode.GetString(buf), false));
                      }
                  }
              });
        }

        private void ConnectionCancel(object obj)
        {
            try
            {
                IAsyncResult res = (IAsyncResult)obj;
                Client.EndConnect(res);
            }
            catch (Exception) { }
        }

        private void SendCommand()
        {
            if (Client.Connected)
            {
                byte[] arr = System.Text.Encoding.Unicode.GetBytes(MessageToSend);
                Messages.Add(new TestMessage(MessageToSend));
                MessageToSend = string.Empty;

                try
                {
                    IAsyncResult res = Client.GetStream().BeginWrite(arr, 0, arr.Length, null, null);
                    Timer timer = new Timer(new TimerCallback(WriteCancel), res, 2000, Timeout.Infinite);
                }
                catch (Exception) { }
            }
        }

        private void WriteCancel(object obj)
        {
            try
            {
                IAsyncResult res = (IAsyncResult)obj;
                Client.GetStream().EndWrite(res);
            }
            catch (Exception) { }
        }
    }
}
