namespace ContosoUniversity.Entities
{
    public class Enrollment: Entity
    {
        public Grade? Grade { get; init; }
        public Course Course { get; init; } = null!;
        public Student Student { get; init; } = null!;
        public int StudentId { get; init; }

        public int CourseId { get; init; }
    }
}
