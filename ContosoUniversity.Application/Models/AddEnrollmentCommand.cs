namespace ContosoUniversity.Models
{
    public class AddEnrollmentCommand
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Grade Grade { get; set; }
    }
}
