using Newtonsoft.Json;
using QnectMe.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QnectMe.Classes
{
    public class QR
    {
        public static ZXingBarcodeImageView Generate()
        {
            var qr = new ZXingBarcodeImageView();
            qr.HorizontalOptions = LayoutOptions.FillAndExpand;
            qr.VerticalOptions = LayoutOptions.FillAndExpand;
            qr.BarcodeOptions.Width = 200;
            qr.BarcodeOptions.Height = 200;
            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeValue = JsonConvert.SerializeObject(App.DB.GetMyProfile());

            return qr;
        }

        public async void ScanAsync()
        {
            var data = await DependencyService.Get<Interfaces.IQRScanner>().ScanAsync();

            if (data != null)
            {
                Account json = JsonConvert.DeserializeObject<Account>(data);
                App.DB.Create(json);
                IsSuccessfullyAdded(true);
            }
            else IsSuccessfullyAdded(false);
        }

        public delegate void ScannedAddedHandler(bool isAdded);
        public event ScannedAddedHandler IsSuccessfullyAdded;
    }
}
