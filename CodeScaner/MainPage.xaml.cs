using CodeScaner.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

namespace CodeScaner
{
    public partial class MainPage : ContentPage
    {
        private double width = 0;
        private double height = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;

                if (width > height)
                {
                    layout.Orientation = StackOrientation.Horizontal;
                }
                else
                {
                    layout.Orientation = StackOrientation.Vertical;
                }
            }
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private async void OpenScanner(object sender, EventArgs e)
        {
            var scanner = new MobileBarcodeScanner();
            var scanned = await scanner.Scan();

            if (scanned != null)
            {
                //result.Text = scanned.Text;
            }
        }

        private void InputCode(object sender, EventArgs e)
        {

        }

        private void OpenServerChat(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ServerChatPage());
        }
    }
}
