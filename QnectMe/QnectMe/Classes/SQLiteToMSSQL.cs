using System;
using System.Collections.Generic;
using System.Net.Http;

namespace QnectMe.Classes
{
    public static class SQLiteToMSSQL
    {
        public static void Synchronize()
        {
            var uri = new Uri(Properties.Resources.DefaultEndpoint + ":" + Properties.Resources.DefaultPort + "/UserProfileModelsWeb/Create/");
            var account = App.DB.GetMyProfile();

            using (var client = new HttpClient() { BaseAddress = uri })
            {
                var contentToSend = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("ID", account.ID.ToString()),
                        new KeyValuePair<string, string>("Name", account.Name),
                        new KeyValuePair<string, string>("Number", account.Number),
                        new KeyValuePair<string, string>("Company", account.Company),
                        new KeyValuePair<string, string>("Email", account.Email),
                        new KeyValuePair<string, string>("Skype", account.Skype),
                        new KeyValuePair<string, string>("LI", account.LI),
                        new KeyValuePair<string, string>("FB", account.FB),
                        new KeyValuePair<string, string>("VK", account.VK),
                        //new KeyValuePair<string, string>("__RequestVerificationToken", AuthToken.Registration(uri).Result),
                    });

                var response = client.PostAsync(client.BaseAddress, contentToSend).Result;
            }

        }
    }
}
