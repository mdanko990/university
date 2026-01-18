using ContosoUniversity.Entities;

namespace ContosoUniversity.Tests.Entities
{
    public class StudentTest
    {
        [Fact]
        public void AddEnrollment_NonExisting_Added()
        {
            // Arrange
            var student = new Student() { Id = 1, FirstName = string.Empty, LastName = string.Empty };
            // Act
            bool observed = student.AddEnrollment(1, Grade.A);
            // Assert
            Assert.True(observed);
        }

        [Fact]
        public void AddEnrollment_Existing_NotAdded()
        {
            // Arrange
            var student = new Student() { Id = 1, FirstName = string.Empty, LastName = string.Empty };
            // Act
            student.AddEnrollment(1, Grade.A);

            bool observed = student.AddEnrollment(1, Grade.D);
            // Assert
            Assert.False(observed);
        }

        [Fact]
        public void DeleteEnrollment_NonExisting_NotDeleted()
        {
            var student = new Student() { Id = 1, FirstName = string.Empty, LastName = string.Empty };

            bool observed = student.DeleteEnrollment(1);
            Assert.False(observed);
        }

        [Fact]
        public void DeleteEnrollment_ExistingById_Deleted()
        {
            var student = new Student() { Id = 1, FirstName = string.Empty, LastName = string.Empty };
            student.AddEnrollment(1, Grade.A);

            bool observed = student.DeleteEnrollment(student.Enrollments.Single().Id);
            Assert.True(observed);

        }
    }
}
