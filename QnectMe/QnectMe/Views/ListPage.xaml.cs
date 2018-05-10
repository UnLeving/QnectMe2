using QnectMe.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QnectMe.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TESTPage1 : ContentPage
    {
        public TESTPage1()
        {
            InitializeComponent();
            
            MyListView.ItemsSource = App.DB.Get();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            
            await Navigation.PushModalAsync(new QProfilePage(e.Item as Account));
            
            ((ListView)sender).SelectedItem = null;
        }
    }
}
