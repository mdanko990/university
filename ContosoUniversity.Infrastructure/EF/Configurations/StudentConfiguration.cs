using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.Configurations;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> configuration)
    {
        configuration
            .Property(b => b.LastName)
            .IsRequired()
            .HasMaxLength(32);

        configuration
            .Property(b => b.FirstName)
            .IsRequired()
            .HasMaxLength(32);

        configuration.OwnsOne(o => o.Address);

        configuration.HasData(
            new Student
            {
                Id = 1,
                FirstName = "Carson",
                LastName = "Alexander",
                EnrollmentDate = DateTime.Parse("2010-09-01").ToUniversalTime()
            },
            new Student
            {
                Id = 2,
                FirstName = "Meredith",
                LastName = "Alonso",
                EnrollmentDate = DateTime.Parse("2012-09-01").ToUniversalTime()
            },
            new Student
            {
                Id = 3,
                FirstName = "Arturo",
                LastName = "Anand",
                EnrollmentDate = DateTime.Parse("2013-09-01").ToUniversalTime()
            },
            new Student
            {
                Id = 4,
                FirstName = "Gytis",
                LastName = "Barzdukas",
                EnrollmentDate = DateTime.Parse("2012-09-01").ToUniversalTime()
            },
            new Student
            {
                Id = 5,
                FirstName = "Yan",
                LastName = "Li",
                EnrollmentDate = DateTime.Parse("2012-09-01").ToUniversalTime()
            },
            new Student
            {
                Id = 6,
                FirstName = "Peggy",
                LastName = "Justice",
                EnrollmentDate = DateTime.Parse("2011-09-01").ToUniversalTime()
            },
            new Student
            {
                Id = 7,
                FirstName = "Laura",
                LastName = "Norman",
                EnrollmentDate = DateTime.Parse("2013-09-01").ToUniversalTime()
            },
            new Student
            {
                Id = 8,
                FirstName = "Nino",
                LastName = "Olivetto",
                EnrollmentDate = DateTime.Parse("2005-09-01").ToUniversalTime()
            });
    }
}
