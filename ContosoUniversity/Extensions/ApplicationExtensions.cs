using ContosoUniversity.Factories;
using ContosoUniversity.Services;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(
        this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<SchoolContext>(options =>
            options.UseSqlServer(
        builder.Configuration.GetConnectionString("localConnection")));
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<IStudentFactory, StudentFactory>();
        builder.Services.AddScoped<IStudentService, StudentService>();

        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
    }
}
