namespace ContosoUniversity.Interfaces
{
    public interface IStudentFactory
    {
        Student Create(string lastName, string firstName, DateTime enrollmentDate, string? photoUri, Address? address);
        Student Create(int id, string lastName, string firstName, DateTime enrollmentDate, string? photoUri, Address? address);
    }
}
