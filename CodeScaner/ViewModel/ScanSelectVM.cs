using CodeScaner.Model.Settings;
using CodeScaner.View;
using Plugin.Settings;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Mobile;
using System.Linq;

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
            string formatsDefault = JsonSerializer.Serialize(new ObservableCollection<BarcodeType>(BarcodeType.AllCodes));
            string formatsJson = CrossSettings.Current.GetValueOrDefault("formats", formatsDefault);
            var formats = JsonSerializer.Deserialize<ObservableCollection<BarcodeType>>(formatsJson);
            var avaibleFormats = formats.Where(type => type.IsSelect).SelectMany(type => type.Formats);

            var scanner = new MobileBarcodeScanner();
            scanner.CancelButtonText = "Назад";
            scanner.TopText = "Поднесите к камере код так, чтобы он был единственным в кадре";

            var opts = new MobileBarcodeScanningOptions();
            opts.AutoRotate = true;
            opts.DelayBetweenAnalyzingFrames = 1000;
            opts.PossibleFormats = avaibleFormats;

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
