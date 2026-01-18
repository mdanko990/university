
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.EF
{
    public class StudentRepository : IStudentRepository
    {
        private SchoolContext Context { get; }
        public StudentRepository(SchoolContext context)
        {
            Context = context;
        }
        public async Task Delete(Student student)
        {
            Context.Students.Remove(student);
            await Context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await Context.Students.ToListAsync();
        }

        public async Task<Student?> GetById(int id)
        {
            return await Context.Students.FindAsync(id);
        }

        public async Task<Student?> GetByIdWithEnrollmentById(int id, int enrollmentId)
        {
            return await Context.Students
                .Include(s => s.Enrollments.Where(e => e.Id == enrollmentId))
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> GetByIdWithEnrollments(int id)
        {
            return await Context.Students
                .Include(s => s.Enrollments)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> GetByIdWithEnrollmentsAndCourses(int id)
        {
            return await Context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> Insert(Student student)
        {
            Context.Add(student);
            await Context.SaveChangesAsync();
            return student;
        }

        public async Task Update(Student student)
        {
            Context.Update(student);
            await Context.SaveChangesAsync();
        }
    }
}
