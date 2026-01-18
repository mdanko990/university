
namespace ContosoUniversity.Factories
{
    public class StudentFactory : IStudentFactory
    {
        public Student Create(string lastName, string firstName, DateTime enrollmentDate, string? photoUri, Address? address)
        {
            return new Student()
            {
                LastName = lastName,
                FirstName = firstName,
                EnrollmentDate = enrollmentDate,
                PhotoUri = photoUri,
                Address = address
            };
        }

        public Student Create(int id, string lastName, string firstName, DateTime enrollmentDate, string? photoUri, Address? address)
        {
            return new Student()
            {
                Id = id,
                LastName = lastName,
                FirstName = firstName,
                EnrollmentDate = enrollmentDate,
                PhotoUri = photoUri,
                Address = address
            };
        }
    }
}
