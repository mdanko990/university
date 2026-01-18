using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.Configurations;

internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> configuration)
    {
        configuration
            .Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(40);

        configuration.HasData(
            new Course { Id = 1, Title = "Chemistry", Credits = 3 },
            new Course { Id = 2, Title = "Microeconomics", Credits = 3 },
            new Course { Id = 3, Title = "Macroeconomics", Credits = 3 },
            new Course { Id = 4, Title = "Calculus", Credits = 4 },
            new Course { Id = 5, Title = "Trigonometry", Credits = 4 },
            new Course { Id = 6, Title = "Composition", Credits = 3 },
            new Course { Id = 7, Title = "Literature", Credits = 4 });
    }
}
