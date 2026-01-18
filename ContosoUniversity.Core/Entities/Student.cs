namespace ContosoUniversity.Entities
{
    public class Student: Entity, IAggregateRoot
    {
        public required string LastName { get; init; }
        public required string FirstName { get; init; }
        public DateTime EnrollmentDate { get; init; }
        public Address? Address { get; init; }
        public string? PhotoUri { get; init; }
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

        public bool AddEnrollment(int courseId, Grade grade)
        {
            if (_enrollments.Exists(e => e.CourseId == courseId))
            {
                return false;
            }
            var enrollment = new Enrollment()
            {
                Student = this,
                CourseId = courseId,
                Grade = grade
            };
            _enrollments.Add(enrollment);
            return true;
        }
        public bool DeleteEnrollment(int enrollmentId)
        {
            var enrollment = _enrollments.SingleOrDefault(e => e.Id == enrollmentId);
            if (enrollment == null)
            {
                return false;
            }
            return _enrollments.Remove(enrollment);
        }
    }
}
