using Microsoft.EntityFrameworkCore;
using QnectMe.NetCore20.Models;

namespace QnectMe.NetCore20.Data
{
    public class UserProfileContext : DbContext
    {
        public UserProfileContext(DbContextOptions<UserProfileContext> options) : base(options) { }

        public DbSet<UserProfileModel> UserProfiles { get; set; }
    }
}
