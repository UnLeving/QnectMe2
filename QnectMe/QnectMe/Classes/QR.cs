using Newtonsoft.Json;
using QnectMe.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QnectMe.Classes
{
    public static class QR
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

        public async static Task<bool> ScanAsync()
        {
            var data = await DependencyService.Get<Interfaces.IQRScanner>().ScanAsync();

            if (data != null)
            {
                Account json = JsonConvert.DeserializeObject<Account>(data);
                App.DB.Create(json);
                return true;
            }
            return false;
        }

        //public static void LaunchIntents(List<Account> list)
        //{
        //    foreach (var item in list)
        //    {
        //        if (item.Number != "")
        //            PhoneContact.CreateContact(item);
        //        else
        //            SocialNetwork.SendRequest(item);
        //    }
        //}
    }
}
