using CodeScaner.View;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Mobile;

namespace CodeScaner.ViewModel
{
    public class ScanSelectVM
    {
        public ICommand OpenScaner { get; }
        public ICommand EnterCode { get; }

        private INavigation navigation;

        public ScanSelectVM(INavigation navigationContext)
        {
            this.navigation = navigationContext;
            this.OpenScaner = new Command(ScanAsync);
            this.EnterCode = new Command(Enter);
        }

        private async void ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
            {
                if (!string.IsNullOrWhiteSpace(result.Text))
                    await this.navigation.PushAsync(new ChangeStatusPage(result.Text));
            }
        }

        private async void Enter()
        {
            await this.navigation.PushAsync(new ChangeStatusPage());
        }
    }
}
