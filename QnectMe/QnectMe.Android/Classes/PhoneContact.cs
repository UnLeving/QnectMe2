using Android.Content;
using QnectMe.Models;
using Xamarin.Forms;
using static Android.Provider.ContactsContract;

[assembly: Dependency(typeof(QnectMe.Droid.Classes.PhoneContact))]
namespace QnectMe.Droid.Classes
{
    public class PhoneContact : Interfaces.IPhoneContact
    {
        readonly int PROTOCOL_SKYPE = 3;

        public void CreateContact(Account account)
        {
            var intent = new Intent(Intents.Insert.Action);
            intent.SetType(RawContacts.ContentType);

            intent.PutExtra(Intents.Insert.Name, account.Name);
            if (account.Company != "") intent.PutExtra(Intents.Insert.Company, account.Company);
            if (account.Number != "") intent.PutExtra(Intents.Insert.Phone, account.Number);
            if (account.Email != "") intent.PutExtra(Intents.Insert.Email, account.Email);
            if (account.Skype != "")
            {
                intent.PutExtra(Intents.Insert.ImProtocol, PROTOCOL_SKYPE);
                intent.PutExtra(Intents.Insert.ImHandle, account.Skype);
            }

#pragma warning disable CS0618 // Type or member is obsolete
            Forms.Context.StartActivity(intent);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}