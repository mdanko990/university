using ContosoUniversity.Entities;
using ContosoUniversity.Interfaces;
using ContosoUniversity.Services;
using Moq;

namespace ContosoUniversity.Tests.Services
{
    public class StudentServiceTest
    {
        [Fact]
        public async Task ListStudents_MockingStudentRepository_GetAll()
        {
            var mock = new Mock<IStudentRepository>();
            IEnumerable<Student> students = new List<Student>()
            {
                new Student() {Id= 1, LastName = "L1", FirstName ="F1", EnrollmentDate = DateTime.Today},
                new Student() {Id= 2, LastName = "L2", FirstName ="F2", EnrollmentDate = DateTime.Today},
                new Student() {Id= 3, LastName = "L3", FirstName ="F3", EnrollmentDate = DateTime.Today}
            };
            mock.Setup(p => p.GetAll()).ReturnsAsync(students);
            var service = new StudentService(null, mock.Object);
            var result = await service.ListStudents();
            Assert.Equal(3, result.Count());
        }
    }
}
