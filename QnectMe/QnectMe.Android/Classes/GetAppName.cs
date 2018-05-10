using Xamarin.Forms;
using QnectMe.Droid.Classes;
using QnectMe.Interfaces;

[assembly: Dependency(typeof(GetAppName))]
namespace QnectMe.Droid.Classes
{
    public class GetAppName : IGetAppName
    {
        public string GetName()
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var activity = Forms.Context as MainActivity;
#pragma warning restore CS0618 // Type or member is obsolete
            return activity.ApplicationInfo.PackageName;
        }
    }
}