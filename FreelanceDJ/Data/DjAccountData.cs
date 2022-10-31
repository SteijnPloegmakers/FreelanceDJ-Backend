using FreelanceDJ.Models.DjAccount;
using Microsoft.EntityFrameworkCore;

namespace FreelanceDJ.Data
{
    public class DjAccountData : DbContext
    {
        public DjAccountData(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DjAccount> DjAccounts { get; set; }
    }
}
