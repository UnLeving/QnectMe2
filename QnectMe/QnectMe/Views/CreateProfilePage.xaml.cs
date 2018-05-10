using QnectMe.Classes;
using QnectMe.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QnectMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProfilePage : ContentPage
    {
        public CreateProfilePage()
        {
            InitializeComponent();
            this.BindingContext = new Account();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            var account = BindingContext as Account;
            if (string.IsNullOrWhiteSpace(account.Name)) return;

            App.DB.Create(account);

            await Navigation.PopModalAsync();
        }

        //private void ChoosePhoto_Clicked(object sender, System.EventArgs e)
        //{
        //    ImagePicker.GetPhoto();
        //    MessagingCenter.Subscribe<AccountPage, Uri>(this, "Hi",(send, arg)=> {
                
        //        image.Source = arg;
        //    });
        //}
    }
}