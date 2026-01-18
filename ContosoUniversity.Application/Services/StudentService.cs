using ContosoUniversity.Interfaces;
using ContosoUniversity.Models;

namespace ContosoUniversity.Services;

public class StudentService : IStudentService
{
    private IStudentFactory Factory { get; }
    private IStudentRepository StudentRepository { get; }

    public StudentService(
        IStudentFactory factory,
        IStudentRepository studentRepository)
    {
        Factory = factory;
        StudentRepository = studentRepository;
    }

    public async Task<IEnumerable<Student>> ListStudents()
    {
        return await StudentRepository.GetAll();
    }

    public async Task<Student?> GetStudentForDetails(int id)
    {
        return await StudentRepository.GetByIdWithEnrollmentsAndCourses(id);
    }

    public async Task<Student?> GetStudentWithEnrollment(int id, int enrollmentId)
    {
        return await StudentRepository.GetByIdWithEnrollmentById(id, enrollmentId);
    }

    public async Task<Student> AddNewStudent(AddStudentCommand command)
    {
        var student = Factory.Create(
            command.LastName, command.FirstName, command.EnrollmentDate, command.PhotoUri, null);
        return await StudentRepository.Insert(student);
    }


    public async Task<Student?> AddEnrollment(int id, AddEnrollmentCommand command)
    {
        var student = await StudentRepository.GetByIdWithEnrollments(command.StudentId);
        if (student != null && student.AddEnrollment(command.CourseId, command.Grade))
        {
            await StudentRepository.Update(student);
        }
        return student;
    }


    public async Task<bool> EditExistingStudent(int id, EditStudentCommand command)
    {
        try
        {
            var student = Factory.Create(
                command.Id, command.LastName, command.FirstName, command.EnrollmentDate, command.PhotoUri, null);
            await StudentRepository.Update(student);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteExistingStudent(int id)
    {
        var student = await StudentRepository.GetById(id);
        if (student == null)
        {
            return false;
        }
        await StudentRepository.Delete(student);
        return true;
    }

    public async Task<bool> DeleteExistingEnrollment(int id, int enrollementId)
    {
        var student = await StudentRepository.GetByIdWithEnrollments(id);
        if (student != null)
        {
            if (student.DeleteEnrollment(enrollementId))
            {
                await StudentRepository.Update(student);
                return true;
            }
        }
        return false;
    }

}
