using QnectMe.Classes;
using QnectMe.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QnectMe
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            var data = App.DB.GetMyProfile();
            if (data != null)
            {
                btn_generateQR.IsVisible = true;
                btn_scanQR.IsVisible = true;
            }
            else btn_generateQR.IsVisible = false;

            base.OnAppearing();
        }

        async void btn_generateQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new QRPage());
        }

        async void btn_readQR_Clicked(object sender, EventArgs e)
        {
            bool isScannedSomething = await QR.ScanAsync();

        }

        async void btn_myProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MyProfilePage());
        }

        async void MyQ_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TESTPage1());
        }

        //private void GroupByEventClicked(object sender, EventArgs e)
        //{
        //    eventName.IsEnabled = true;
        //    eventName.IsVisible = true;
        //}
    }
}
