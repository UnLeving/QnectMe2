using QnectMe.Classes;
using QnectMe.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QnectMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QProfilePage : ContentPage
    {
        public QProfilePage()
        {

        }
        public QProfilePage(Account account)
        {
            InitializeComponent();
            BindingContext = account;
            //DisplayAlert("from Q", ID, "OK");
        }

        private void LabelNumberTappedEvent(object sender, System.EventArgs e)
        {
            PhoneContact.CreateContact(new Account() { Name = labelName.Text, Number = labelNumber.Text, Company = labelCompany.Text, Email = labelEmail.Text, Skype = labelSkype.Text });
        }

        private void LabelLiTappedEvent(object sender, System.EventArgs e)
        {
            SocialNetwork.LI(labelLI.Text);
        }

        private void LabelFBTappedEvent(object sender, System.EventArgs e)
        {
            SocialNetwork.FB(labelFB.Text);
        }
    }
}