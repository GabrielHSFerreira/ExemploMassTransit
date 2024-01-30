using ExemploMassTransit.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace ExemploMassTransit.Persistence.Contexts
{
    public class ExemploContext : DbContext
    {
        public DbSet<Order> Orders => Set<Order>();

        public ExemploContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExemploContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}