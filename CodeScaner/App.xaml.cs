using CodeScaner.Service;
using CodeScaner.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace CodeScaner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterServices();

            MainPage = new NavigationPage(new AuthorizationPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=29404732-7ceb-40c9-b92a-efd87c236f25;" +
                  "ios=29404732-7ceb-40c9-b92a-efd87c236f25",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void RegisterServices()
        {
            ServiceLocator<IProtobufServer>.RegisterService(new ProtobufServer());
        }
    }
}
