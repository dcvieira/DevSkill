using DevSkill.Domain.Order.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevSkill.Persistence.Configurations
{
    public class OrderDetailsConfigurationConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.Property(c => c.SecuityCode).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Country).HasMaxLength(50).IsRequired();
            builder.Property(c => c.NameOnCard).HasMaxLength(50).IsRequired();
            builder.Property(c => c.PostalCode).HasMaxLength(50).IsRequired();


            builder.OwnsOne(t => t.CreditCardNumber)
              .Property(t => t.Value)
              .HasMaxLength(50)
              .IsRequired();


        }
    }

}
