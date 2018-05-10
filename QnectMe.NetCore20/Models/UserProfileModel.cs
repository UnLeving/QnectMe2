using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QnectMe.NetCore20.Models
{
    public class UserProfileModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Your name")]
        public string Name { get; set; }
        [DisplayName("Your phone number")]
        public string Number { get; set; }
        [DisplayName("Your company name")]
        public string Company { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Skype ID")]
        public string Skype { get; set; }
        [DisplayName("Linkedin ID")]
        public string LI { get; set; }
        [DisplayName("Facebook ID")]
        public string FB { get; set; }
        [DisplayName("Vkontekte ID")]
        public string VK { get; set; }
    }
}
