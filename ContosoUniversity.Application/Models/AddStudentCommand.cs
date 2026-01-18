namespace ContosoUniversity.Models
{
    public class AddStudentCommand
    {
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string? PhotoUri { get; set; }
    }
}
