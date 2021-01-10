using CodeScaner.ViewModel;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeScaner.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            this.Title = "Настройки";
            InitializeComponent();
            this.BindingContext = new SettingsVM();
        }
    }
}