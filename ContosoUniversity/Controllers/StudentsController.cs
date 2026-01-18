using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private IStudentService StudentService { get; }

    public StudentsController(IStudentService service)
    {
        StudentService = service;
    }

    // GET: api/Students
    [HttpGet]
    public async Task<IEnumerable<Student>> GetStudents()
    {
        return await StudentService.ListStudents();
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await StudentService.GetStudentForDetails(id);
        if (student == null)
        {
            return NotFound();
        }

        return student;
    }

    // POST: api/Students
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(AddStudentCommand studentModel)
    {
        var student = await StudentService.AddNewStudent(studentModel);
        return CreatedAtAction("GetStudent", new { id = student.Id }, student);
    }

    // PUT: api/Students/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, EditStudentCommand command)
    {
        if (!await StudentService.EditExistingStudent(id, command))
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        if (!await StudentService.DeleteExistingStudent(id))
        {
            return NotFound();
        }

        return NoContent();
    }

    // GET: api/Students/{studentId}/enrollments/{enrollementId}
    [HttpGet("{studentId}/enrollments/{enrollementId}")]
    public async Task<ActionResult<Student>> GetEnrollment(int studentId, int enrollementId)
    {
        Student? student = await StudentService.GetStudentWithEnrollment(studentId, enrollementId);
        if (student == null)
        {
            return NotFound();
        }
        return student;
    }

    // POST: api/Students/{Id}/enrollments
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("{id}/enrollments")]
    public async Task<ActionResult<Student>> PostEnrollment(int id, AddEnrollmentCommand command)
    {
        var student = await StudentService.AddEnrollment(id, command);
        if (student == null)
        {
            return NotFound();
        }
        return CreatedAtAction("GetStudent", new { id = student.Id }, student);
    }

    // DELETE: api/Students/{studentId}/enrollments/{enrollementId}
    [HttpDelete("{studentId}/enrollments/{enrollementId}")]
    public async Task<IActionResult> DeleteEnrollment(int studentId, int enrollementId)
    {
        if (!await StudentService.DeleteExistingEnrollment(studentId, enrollementId))
        {
            return NotFound();
        }

        return NoContent();
    }
    
}
