using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListStudents();
        Task<Student?> GetStudentForDetails(int id);
        Task<Student?> GetStudentWithEnrollment(int id, int enrollmentId);
        Task<Student> AddNewStudent(AddStudentCommand command);
        Task<Student?> AddEnrollment(int id, AddEnrollmentCommand
        command);
        Task<bool> EditExistingStudent(int id, EditStudentCommand
        command);
        Task<bool> DeleteExistingStudent(int id);
        Task<bool> DeleteExistingEnrollment(int Id, int enrollementId);
    }
}
