using QnectMe.Interfaces;
using Xamarin.Forms;

namespace QnectMe.Classes
{
    public static class GoogleSignIn
    {
        public static void SignIn()
        {
            DependencyService.Get<IGoogleSignIn>().SignIn();
        }

        public static void SignOut()
        {
            DependencyService.Get<IGoogleSignIn>().SignOut();
        }
    }
}
