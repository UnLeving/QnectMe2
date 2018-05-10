using Xamarin.Forms;

namespace QnectMe.Classes
{
    public static class SocialNetwork
    {
        public static void LI(string item)
        {
            DependencyService.Get<Interfaces.ISocialNetwork>().LI(item);
        }

        public static void FB(string item)
        {
            DependencyService.Get<Interfaces.ISocialNetwork>().FB(item);
        }
    }
}
