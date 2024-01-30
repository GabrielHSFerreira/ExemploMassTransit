using ExemploMassTransit.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExemploMassTransit.Persistence.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired();
            builder.Property(x => x.CreatedAt)
                .IsRequired();
            builder.Property(x => x.ChangedAt)
                .IsRequired();
            builder.Property(x => x.Customer)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasIndex(x => x.CreatedAt)
                .IsDescending();
        }
    }
}