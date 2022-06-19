using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Document> Document { get; set; }
    }
}
