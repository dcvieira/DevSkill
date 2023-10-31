using DevSkill.Domain.Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevSkill.Persistence.Configurations
{
    public class CourseConfigurationConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(150).IsRequired();
            builder.Property(c => c.ImageUrl).HasMaxLength(450).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.Duration).IsRequired();
            builder.HasOne(c => c.Category).WithMany().HasForeignKey(c => c.CategoryId);
        }
    }

}
