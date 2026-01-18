namespace ContosoUniversity.Models
{
    public class EditStudentCommand
    {
        public int Id { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string? PhotoUri { get; set; }
    }
}
