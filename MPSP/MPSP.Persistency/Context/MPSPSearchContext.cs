using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MPSP.Model.Search;

namespace MPSP.Persistency.Context
{
    public class MPSPSearchContext : DbContext
    {
        public DbSet<Jucesp> Jucesp { get; set; }
        public DbSet<Siel> Siel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }
    }
}

