using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QnectMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRPage : ContentPage
    {
        public QRPage()
        {
            InitializeComponent();
            Content = Classes.QR.Generate();
        }
    }
}