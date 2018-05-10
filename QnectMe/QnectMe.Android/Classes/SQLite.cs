using System;
using Xamarin.Forms;
using QnectMe.Interfaces;
using System.IO;

[assembly: Dependency(typeof(QnectMe.Droid.Classes.SQLite))]
namespace QnectMe.Droid.Classes
{
    public class SQLite : ISQLite
    {
        public string GetDBPath(string fileName)
        {
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(documentPath, fileName);
        }
    }
}