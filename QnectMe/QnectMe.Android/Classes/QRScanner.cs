using QnectMe.Interfaces;
using System.Threading.Tasks;
using ZXing.Mobile;

[assembly: Xamarin.Forms.Dependency(typeof(QnectMe.Droid.Classes.QRScanner))]
namespace QnectMe.Droid.Classes
{
    public class QRScanner : IQRScanner
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Auto scanner"
            };

            var res = await scanner.Scan(new MobileBarcodeScanningOptions());

            return res?.Text;
        }
    }
}