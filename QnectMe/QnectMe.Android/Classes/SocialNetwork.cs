using Android.Content;
using Android.Net;
using QnectMe.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(QnectMe.Droid.Classes.SocialNetwork))]
namespace QnectMe.Droid.Classes
{
    public class SocialNetwork : Interfaces.ISocialNetwork
    {
        string partOfUri = "://profile/";
        string LIpartOfUri = "://profile/in/";

        public void FB(string item)
        {
            Func(AccountType.fb.ToString(), item, Properties.Resources.linkFB, Properties.Resources.droidPackName_FB, partOfUri);
        }

        public void LI(string item)
        {
            Func(AccountType.linkedin.ToString(), item, Properties.Resources.linkLI, Properties.Resources.droidPackName_LI, LIpartOfUri);
        }

        void Func(string socialNetworkType, string profileId, string socialNetworkLink, string packageName, string profileStr)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var res = Forms.Context.PackageManager.GetLaunchIntentForPackage(packageName);
#pragma warning restore CS0618 // Type or member is obsolete
            var intent = new Intent(Intent.ActionView);
            var uri = "";

            if (res != null)
                uri = socialNetworkType + profileStr + profileId;
            else
                uri = socialNetworkLink + profileId;

            intent.SetData(Uri.Parse(uri));

            intent.AddFlags(ActivityFlags.NewTask);
#pragma warning disable CS0618 // Type or member is obsolete
            Forms.Context.StartActivity(intent);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}