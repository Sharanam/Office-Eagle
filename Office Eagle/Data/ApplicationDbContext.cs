using Microsoft.EntityFrameworkCore;
using Office_Eagle.Models;

namespace Office_Eagle.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
    }
}
