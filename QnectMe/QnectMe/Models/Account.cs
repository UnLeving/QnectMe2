using SQLite;
using System;

namespace QnectMe.Models
{
    [Table("Accounts")]
    public class Account
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int ID { get; private set; }
        
        public string Name { get; set; }
        public string Number { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Skype { get; set; }
        public string LI { get; set; }
        public string FB { get; set; }
        public string VK { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Location { get; set; }

        public Account() { }

        public Account(string name, string number = "", string company = "", string li = "", string fb = "", string skype = "", string email = "", string vk = "", string location = "")
        {
            this.Name = name;
            this.Number = number;
            this.Company = company;
            this.Email = email;
            this.Skype = skype;
            this.LI = li;
            this.FB = fb;
            this.VK = vk;
            this.Location = location;
            this.CreatedTime = DateTime.Now;
        }
    }
}

public enum AccountType
{
    phoneNumber,
    vk,
    fb,
    linkedin,
    skype
}