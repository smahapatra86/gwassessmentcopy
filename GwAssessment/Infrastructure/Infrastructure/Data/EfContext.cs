using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Scans a given assembly for all types that implement IEntityTypeConfiguration, and registers each one automatically
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Customer>()
            //.Property(p => p.Name)
            //.HasConversion(
            //    p => p,
            //    p => Name.FromValue(p));

            base.OnModelCreating(modelBuilder);
        }
    }
}
