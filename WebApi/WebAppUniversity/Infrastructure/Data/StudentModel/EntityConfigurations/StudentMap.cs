using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAppUniversity.Domain;

namespace WebAppUniversity.Infrastructure.Configurations
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Surname).HasMaxLength(255).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

            builder.Property(x => x.Patronymic).HasMaxLength(255).IsRequired();

            builder.Property(x => x.Age);

            builder.Property(x => x.ClassId);
        }
    }
}
