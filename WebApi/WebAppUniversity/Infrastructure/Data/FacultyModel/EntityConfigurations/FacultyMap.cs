using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppUniversity.Domain;

namespace WebAppUniversity.Infrastructure.Configurations
{
    public class FacultyMap : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

            builder.Property(x => x.Dean).HasMaxLength(255).IsRequired();
        }
    }
}
