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
                if (!msg.Equals(value))
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
                if (!status.Equals(value))
                {
                    status = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(ConnectionStatus)));
                }
            }
        }

        public ICommand Send { get; }

        public TcpClient Client { get; private set; } = new TcpClient();

        public ServerChatVM()
        {
            status = "Подключение";
            Client.SendTimeout = 2000;
            Send = new Command(() => new Thread(StartSend).Start());
            Connect();
        }

        private void Connect()
        {
            Thread thr = new Thread(() =>
              {
                  string[] ipPort = CrossSettings.Current.GetValueOrDefault("ip:port", "0.0.0.0:0").Split(':');
                  status = "Подключение к " + ipPort[0] + ":" + ipPort[1];
                  try
                  {
                      Timer timer = new Timer(new TimerCallback(ConnectionCancel), null, 5000, Timeout.Infinite);
                      Client.Connect(IPAddress.Parse(ipPort[0]), int.Parse(ipPort[1]));
                      ConnectionStatus = "Поключено к " + ipPort[0] + ":" + ipPort[1];
                      StartRead();
                  }
                  catch (SocketException ex)
                  {
                      ConnectionStatus = ex.Message;
                  }
              });
            if (thr.ThreadState == ThreadState.Unstarted)
                thr.Start();
        }

        private void ConnectionCancel(object obj)
        {
            if (!Client.Connected)
                Client.Close();
        }

        private void StartRead()
        {
            while (Client.Connected)
            {
                if (Client.Available > 0)
                {
                    byte[] buf = new byte[Client.Available];
                    Client.GetStream().Read(buf, 0, buf.Length);
                    string message = System.Text.Encoding.Unicode.GetString(buf);

                    Messages.Add(new TestMessage(message, false));
                }
            }
        }

        private void StartSend()
        {
            if (Client.Connected)
            {
                byte[] buf = System.Text.Encoding.Unicode.GetBytes(MessageToSend);
                Messages.Add(new TestMessage(MessageToSend));
                MessageToSend = string.Empty;

                try
                {
                    Client.GetStream().Write(buf, 0, buf.Length);
                }
                catch (Exception ex)
                {
                    ConnectionStatus = ex.Message;
                }
            }
        }
    }
}
