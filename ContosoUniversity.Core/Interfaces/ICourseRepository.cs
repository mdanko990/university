namespace ContosoUniversity.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
    }
}
