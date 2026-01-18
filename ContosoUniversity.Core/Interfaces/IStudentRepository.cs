namespace ContosoUniversity.Interfaces;

public interface IStudentRepository : IRepository<Student>
{
    Task<IEnumerable<Student>> GetAll();
    Task<Student?> GetById(int id);
    Task<Student?> GetByIdWithEnrollments(int id);
    Task<Student?> GetByIdWithEnrollmentById(int id, int enrollmentId);
    Task<Student?> GetByIdWithEnrollmentsAndCourses(int id);
    Task<Student> Insert(Student student);
    Task Update(Student student);
    Task Delete(Student student);
}
