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

            if (App.DB.Get().Count() == 0)
                btn_myqlist.IsVisible = false;

            base.OnAppearing();
        }

        async void btn_generateQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new QRPage());
        }

        void btn_readQR_Clicked(object sender, EventArgs e)
        {
            QR qR = new QR();
            qR.IsSuccessfullyAdded += QR_IsSuccessfullyAdded;
            qR.ScanAsync();
        }

        private void QR_IsSuccessfullyAdded(bool isAdded)
        {
            if (isAdded)
            {
                DisplayAlert("New scan", "New Q successfully added", "Ok");
                btn_myqlist.IsVisible = true;
            }
            else
                DisplayAlert("New scan", "New Q NOT added", "Ok");
        }

        async void btn_myProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MyProfilePage());
        }

        async void MyQ_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TESTPage1());
        }
    }
}
