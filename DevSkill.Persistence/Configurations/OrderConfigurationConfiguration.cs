using DevSkill.Domain.Order.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevSkill.Persistence.Configurations
{
    public class OrderConfigurationConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(c => c.CourseName).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.OrderDate).IsRequired();
            builder.Property(c => c.OrderStatus).IsRequired();
            builder.Property(c => c.UserId).HasMaxLength(50).IsRequired();
            builder.HasOne(c => c.OrderDetails).WithOne().HasForeignKey<OrderDetails>(c => c.OrderId);
        }
    }

}
