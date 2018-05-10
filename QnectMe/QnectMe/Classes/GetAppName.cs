using QnectMe.Interfaces;
using Xamarin.Forms;

namespace QnectMe.Classes
{
    public static class GetAppName
    {
        public static string GetName() => DependencyService.Get<IGetAppName>().GetName();
    }
}