using QnectMe.Interfaces;
using QnectMe.Models;
using Xamarin.Forms;

namespace QnectMe.Classes
{
    public static class PhoneContact
    {
        public static void CreateContact(Account account)
        {
            DependencyService.Get<IPhoneContact>().CreateContact(account);
        }
    }
}
