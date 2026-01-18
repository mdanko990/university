using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.EF
{
    public class CourseRepository : ICourseRepository
    {
        private SchoolContext Context { get; }
        public CourseRepository(SchoolContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await Context.Courses.ToListAsync();
        }
    }
}
