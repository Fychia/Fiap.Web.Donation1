using Fiap.Web.Donation1.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ModelTypeProduct> TypeProducts { get; set; }
        public DbSet<ModelProduct> ModelProducts { get; set; }
        public DbSet<ModelUser> ModelUser { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
