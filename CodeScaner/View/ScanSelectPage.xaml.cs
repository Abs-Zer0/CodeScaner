using CodeScaner.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeScaner.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanSelectPage : ContentPage
    {
        public ScanSelectPage()
        {
            this.Title = "Метод введения данных";
            InitializeComponent();
            this.BindingContext = new ScanSelectVM(this.Navigation);
        }
    }
}