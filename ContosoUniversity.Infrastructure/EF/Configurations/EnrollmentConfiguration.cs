using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.Configurations;

internal class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> configuration)
    {
        configuration.HasData(
            new
            {
                Id = 1,
                StudentId = 1,
                CourseId = 1,
                Grade = Grade.A
            },
            new
            {
                Id = 2,
                StudentId = 1,
                CourseId = 2,
                Grade = Grade.C
            },
            new
            {
                Id = 3,
                StudentId = 1,
                CourseId = 3,
                Grade = Grade.B
            },
            new
            {
                Id = 4,
                StudentId = 2,
                CourseId = 4,
                Grade = Grade.B
            },
            new
            {
                Id = 5,
                StudentId = 2,
                CourseId = 5,
                Grade = Grade.B
            },
            new
            {
                Id = 6,
                StudentId = 2,
                CourseId = 6,
                Grade = Grade.B
            },
            new
            {
                Id = 7,
                StudentId = 3,
                CourseId = 1
            },
            new
            {
                Id = 8,
                StudentId = 3,
                CourseId = 2,
                Grade = Grade.B
            },
            new
            {
                Id = 9,
                StudentId = 4,
                CourseId = 1,
                Grade = Grade.B
            },
            new
            {
                Id = 10,
                StudentId = 5,
                CourseId = 6,
                Grade = Grade.B
            },
            new
            {
                Id = 11,
                StudentId = 6,
                CourseId = 7,
                Grade = Grade.B
            });
    }
}
