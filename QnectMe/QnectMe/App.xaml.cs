using QnectMe.Classes;
using QnectMe.Controllers;
using System;
using System.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace QnectMe
{
	public partial class App : Application
	{
        public const string DB_NAME = "accounts.db";
        public static string APP_NAME = GetAppName.GetName();

        static AccountController db;
        public static Account account;
        public static AccountStore accountStore;

        public static AccountController DB
        {
            get
            {
                if (db == null)
                    db = new AccountController(DB_NAME);
                return db;
            }
        }

        public App()
        {
            InitializeComponent();
            accountStore = AccountStore.Create();
            account = accountStore.FindAccountsForService(APP_NAME).FirstOrDefault();
            MainPage = new MainPage();

            //App.DB.Create(new QnectMe.Models.Account() { Name = "Art James", Number = "111-123-123", LI = "mariam-antonyan-a0a35b104", FB = "Mete0rka", Company =  "Apple", Email =  "123@lol.com", Skype =  "MySkypeID" });
            //App.DB.Create(new QnectMe.Models.Account() { Name = "Bob Fill", Number = "222-3242-2432", LI = "mohammad-sadegh-dabestani-51b63587", FB = "flogger.morozov", Company = "Nokia", Email = "123@lol.com", Skype = "MySkypeID" });
            //App.DB.Create(new QnectMe.Models.Account() { Name = "Gyn Man", Number = "333-23423-2423", LI = "александр-челомбитько-536a85b3", FB = "SergeySA81", Company = "UMC", Email = "123@lol.com", Skype = "MySkypeID" });
        }
    }
}
