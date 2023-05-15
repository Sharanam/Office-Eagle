using Microsoft.EntityFrameworkCore;
using Office_Eagle.Models;

namespace Office_Eagle.Data
{
    public class OfficeEagleDbContext : DbContext
    {
        public OfficeEagleDbContext(DbContextOptions<OfficeEagleDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
    }
}
