using QnectMe.Classes;
using QnectMe.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QnectMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage()
        {
            InitializeComponent();
            UpdateUI();
        }

        protected async override void OnAppearing()
        {
            if (App.DB.GetMyProfile() == null)
                await Navigation.PushModalAsync(new CreateProfilePage());
            BindingContextTrigger();
            base.OnAppearing();
        }

        void btn_Edit_Clicked(object sender, EventArgs e)
        {
            if (btn_Edit.Text == "Edit")
            {
                btn_Edit.Text = "Cancel";
                EntryOnLabelOffSwitcher(true);
            }
            else if (btn_Edit.Text == "Cancel")
            {
                btn_Edit.Text = "Edit";
                EntryOnLabelOffSwitcher(false);
            }
        }

        void btn_Save_Clicked(object sender, EventArgs e)
        {
            btn_Edit.Text = "Edit profile";
            var account = BindingContext as Account;
            if (string.IsNullOrWhiteSpace(account.Name)) return;
            App.DB.Edit(account);
            EntryOnLabelOffSwitcher(false);
            BindingContextTrigger();
        }

        void EntryOnLabelOffSwitcher(bool flag)
        {
            var gridChildrens = grid.Children.Where(c => Grid.GetColumn(c) == 1);
            foreach (var children in gridChildrens)
            {
                if (children is Entry)
                {
                    (children as Entry).IsVisible = flag;
                    (children as Entry).IsEnabled = flag;
                }
                if (children is Label)
                {
                    (children as Label).IsVisible = !flag;
                    (children as Label).IsEnabled = !flag;
                }
            }
            btn_Save.IsEnabled = flag;
            btn_Save.IsVisible = flag;
        }

        void BindingContextTrigger()
        {
            BindingContext = App.DB.GetMyProfile();
        }

        //void GoogleLogInClicked(object sender, EventArgs e)
        //{
        //    GoogleSignIn.SignIn();
        //    AccountStatusCallback();
        //}

        //void LogOutClicked(object sender, EventArgs e)
        //{
        //    GoogleSignIn.SignOut();
        //    AccountStatusCallback();
        //}

        void AccountStatusCallback()
        {
            MessagingCenter.Subscribe<string>(this, "Done", (arg) =>
            {
                UpdateUI();
                //SendIDToken();
            });
        }

       //async void SendIDToken()
       // {
            //using (var httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri("http://192.168.1.200:8080/");
            //    HttpResponseMessage response = await httpClient.PostAsync("Account/GetUserDetails", new StringContent(App.account.Properties.Values.First()));
            //}
        //}

        void UpdateUI()
        {
            bool isSignedIn;
            if (App.accountStore.FindAccountsForService(App.APP_NAME + Properties.Resources.GoogleAuthorization).FirstOrDefault() != null)
                isSignedIn = true;
            else isSignedIn = false;

            //btnGoogleSignIn.IsEnabled = !isSignedIn;
            //btnGoogleSignIn.IsVisible = !isSignedIn;

            //btnGoogleSignOut.IsEnabled = isSignedIn;
            //btnGoogleSignOut.IsVisible = isSignedIn;

            //labelSignIn.Text = isSignedIn ? "Signed-in with Google: " + App.account.Username : "sign-in for web version:";
        }

        //void MicrosoftLogInClicked(object sender, EventArgs e)
        //{
        //    Authorization.LoginWithMicrosoft();
        //    AccountStatusCallback();
        //}
    }
}