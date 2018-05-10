using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace QnectMe.Droid
{
    [Activity(Label = "QnectMe", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, bundle);
            ZXing.Mobile.MobileBarcodeScanner.Initialize(this.Application);
            LoadApplication(new App());
        }

        Action<int, Result, Intent> _resultCallback;

        public void StartActivity(Intent intent, Action<int, Result, Intent> resultCallback)
        {
            _resultCallback = resultCallback;

            StartActivityForResult(intent, 9001);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (_resultCallback != null)
            {
                _resultCallback(requestCode, resultCode, data);
                _resultCallback = null;
            }
        }
    }
}

