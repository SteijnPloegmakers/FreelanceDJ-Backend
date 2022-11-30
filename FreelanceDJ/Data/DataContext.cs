using FreelanceDJ.Models.DjAccount;
using Microsoft.EntityFrameworkCore;

namespace FreelanceDJ.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DjAccount> DjAccounts { get; set; } = null!;
    }
}
