using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeScaner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            FillFields();
        }

        private void FillFields()
        {
            if (!CrossSettings.Current.Contains("ip:port"))
                CrossSettings.Current.AddOrUpdateValue("ip:port", "0.0.0.0:0");

            string ipPort = CrossSettings.Current.GetValueOrDefault("ip:port", "");
            string[] splitted = ipPort.Split('.', ':');

            firstByte.Text = splitted[0];
            secondByte.Text = splitted[1];
            thirdByte.Text = splitted[2];
            fourthByte.Text = splitted[3];
            port.Text = splitted[4];
        }

        private void SomeByteChanged(object sender, TextChangedEventArgs e)
        {
            Entry field = null;
            if (sender == firstByte)
                field = firstByte;
            else if (sender == secondByte)
                field = secondByte;
            else if (sender == thirdByte)
                field = thirdByte;
            else if (sender == fourthByte)
                field = fourthByte;

            if (field != null)
            {
                if (!string.IsNullOrWhiteSpace(field.Text))
                {
                    int val = int.Parse(field.Text);
                    if (val < byte.MinValue)
                        field.Text = byte.MinValue.ToString();
                    if (val > byte.MaxValue)
                        field.Text = byte.MaxValue.ToString();

                    SaveIpPort();
                }
            }
        }

        private void PortChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(port.Text))
            {
                int val = int.Parse(port.Text);
                if (val < ushort.MinValue)
                    port.Text = ushort.MinValue.ToString();
                if (val > ushort.MaxValue)
                    port.Text = ushort.MaxValue.ToString();

                SaveIpPort();
            }
        }

        private void SaveIpPort()
        {
            string ipPort = firstByte.Text + "." + secondByte.Text + "." + thirdByte.Text + "." + fourthByte.Text
                    + ":" + port.Text;
            CrossSettings.Current.AddOrUpdateValue("ip:port", ipPort);
        }
    }
}