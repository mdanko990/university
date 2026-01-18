namespace ContosoUniversity.Entities
{
    public class Course: Entity
    {
        public required string Title { get; init; }
        public int Credits { get; init; }
        List<Enrollment> _enrollments = new List<Enrollment>();
        public IReadOnlyCollection<Enrollment> Enrollments
        {
            get => _enrollments.AsReadOnly();
            set
            {
                if (value != null)
                {
                    _enrollments = value.ToList();
                }
            }
        }
    }
}
