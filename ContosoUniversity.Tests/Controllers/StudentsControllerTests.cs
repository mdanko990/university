namespace ContosoUniversity.Tests.Controllers
{
    public class StudentsControllerTests: AbstractControllerTests
    {
        public StudentsControllerTests(TestApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async void GetStudents_Returns_StudentsArray()
        {
            var students = Client.GetFromJsonAsync<Student[]>("api/students");
            Assert.NotNull(students);
        }
    }
}
