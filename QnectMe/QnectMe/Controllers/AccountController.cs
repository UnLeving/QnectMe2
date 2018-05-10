using QnectMe.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace QnectMe.Controllers
{
    public class AccountController
    {
        SQLiteConnection db;

        public AccountController(string filename)
        {
            var dbPath = DependencyService.Get<Interfaces.ISQLite>().GetDBPath(filename);
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Account>();
        }

        public List<Account> Get() => (from i in db.Table<Account>().Skip(1) select i).ToList();

        public Account Get(int id) => db.Get<Account>(id);

        public Account GetMyProfile()
        {
            if (db.Table<Account>().Count() != 0)
                return db.Get<Account>(1);
            else return null;
        }

        public int Delete(int id) => db.Delete<Account>(id);

        public int Create(Account account)
        {
            if (account.ID != 0)
            {
                db.Update(account);
                return account.ID;
            }
            else return db.Insert(account);
        }

        public void Edit(Account account) => db.Update(account);
    }
}
