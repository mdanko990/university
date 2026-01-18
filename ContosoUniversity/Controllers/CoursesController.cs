using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly SchoolContext _context;

    public CoursesController(SchoolContext context)
    {
        _context = context;
    }

    // GET: api/Courses
    [HttpGet]
    public async Task<IEnumerable<Course>> GetCourses()
    {
        return await _context.Courses.ToListAsync();
    }
 
}
