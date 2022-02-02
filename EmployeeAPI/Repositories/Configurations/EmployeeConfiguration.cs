using DEMO.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DEMO.EmployeeAPI.Repositories.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.Property(p => p.FirstName)
                .HasMaxLength(150);
            builder.Property(p => p.MiddleName)
               .HasMaxLength(150);
            builder.Property(p => p.LastName)
               .HasMaxLength(150);
            builder.Property(p => p.ContactNumber)
               .HasMaxLength(16);
            builder.Property(p => p.EmailAddress)
               .HasMaxLength(150);

        }
    }
}
