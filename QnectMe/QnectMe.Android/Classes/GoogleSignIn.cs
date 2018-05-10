using Android.App;
using Android.Content;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using Android.Gms.Auth.Api.SignIn;
using Xamarin.Forms;
using QnectMe.Interfaces;
using Android.Util;
using System.Collections.Generic;
using Android.OS;
using static Android.Gms.Common.Apis.GoogleApiClient;
using Xamarin.Forms.Platform.Android;
using QnectMe.Droid.Classes;
using Android.Gms.Auth.Api;

[assembly: Dependency(typeof(GoogleSignIn))]
namespace QnectMe.Droid.Classes
{
    public class GoogleSignIn : FormsApplicationActivity, IOnConnectionFailedListener, IConnectionCallbacks, IGoogleSignIn
    {
        const int RC_SIGN_IN = 9001;
        MainActivity activity;
        GoogleApiClient googleApiClient;
        bool isSignInCalled;

        public GoogleSignIn()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            activity = Forms.Context as MainActivity;
#pragma warning restore CS0618 // Type or member is obsolete
            var googleApiAvailability = GoogleApiAvailability.Instance;
            var gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
               .RequestIdToken(Properties.Resources.GoogleClientIdWeb)
               .Build();

            googleApiClient = new Builder(activity)
                .AddConnectionCallbacks(OnConnected)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                .Build();
        }

        public void SignIn()
        {
            isSignInCalled = true;
            var signInIntent = Auth.GoogleSignInApi.GetSignInIntent(googleApiClient);
            activity.StartActivity(signInIntent, ActivityResult);
            googleApiClient.Disconnect();
        }

        public void SignOut()
        {
            googleApiClient.Connect();
            isSignInCalled = false;
        }

        void ActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == RC_SIGN_IN)
            {
                var googleSignInResult = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                HandleSignInResult(googleSignInResult);
            }
        }

        async void HandleSignInResult(GoogleSignInResult result)
        {
            if (result.IsSuccess)
            {
                if (App.account != null)
                    await App.accountStore.DeleteAsync(App.account, App.APP_NAME);

                var googleSignInAccount = result.SignInAccount;
                var dic = new Dictionary<string, string>
                {
                    { "IdToken", googleSignInAccount.IdToken }
                };

                App.account = new Xamarin.Auth.Account(googleSignInAccount.DisplayName, dic);
                await App.accountStore.SaveAsync(App.account, App.APP_NAME + Properties.Resources.GoogleAuthorization);
                MessagingCenter.Send("!", "Done");
            }
            else
            {
                Log.Debug("HandleSignInResult", result.Status?.ToString());
            }
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            Log.Debug("LOGIN", "onConnectionFailed:" + result);
        }

        public async void OnConnected(Bundle connectionHint)
        {
            if (!isSignInCalled)
            {
                await Auth.GoogleSignInApi.SignOut(googleApiClient);
                await App.accountStore.DeleteAsync(App.account, App.APP_NAME + Properties.Resources.GoogleAuthorization);

                googleApiClient.Disconnect();
                MessagingCenter.Send("!", "Done");
            }
        }

        public void OnConnectionSuspended(int cause)
        {
            Log.Debug("OnConnectionSuspended", cause.ToString());
        }
    }
}