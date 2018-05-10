using System;
using Xamarin.Auth;

namespace QnectMe.Classes
{
    public static class Authorization
    {
        public static void LoginWithMicrosoft(string network = "Microsoft")
        {
            string clientId = null;
            string scope = null;
            string authorizeUrl = null;
            string redirectUrl = null;
            string accessTokenUrl = null;
            bool isUsingNativeUI = false;

            switch (network)
            {
                case "Microsoft":
                    clientId = Properties.Resources.MSClientId;
                    scope = Properties.Resources.MSScope;
                    authorizeUrl = Properties.Resources.MSAuthorizeUrl;
                    redirectUrl = Properties.Resources.MSRedirectUrl;
                    accessTokenUrl = Properties.Resources.MSAccessTokenUrl;
                    break;
            }

            var oauth = new OAuth2Authenticator(
                clientId,
                null,
                scope,
                new Uri(authorizeUrl),
                new Uri(redirectUrl),
                new Uri(accessTokenUrl),
                null,
                isUsingNativeUI);

            oauth.Completed += Oauth_Completed;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(oauth);
        }
        
        static void Oauth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= Oauth_Completed;
            }

            if (e.IsAuthenticated)
            {
                if (App.account != null)
                {
                    App.accountStore.Delete(App.account, App.APP_NAME + Properties.Resources.MicrosoftAuthorization);
                }

                App.accountStore.Save(App.account = e.Account, App.APP_NAME + Properties.Resources.MicrosoftAuthorization);
            }
        }
    }
}
