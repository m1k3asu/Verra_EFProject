using EFTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTestProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbOptions) : base(dbOptions)
        {
            
        }

        public DbSet<Project> Projects => Set<Project>();

        public DbSet<Address> Addresses => Set<Address>();
    }
}
