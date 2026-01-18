using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContosoUniversity.Mvc.Controllers;

public class EnrollmentsController : Controller
{
    private IHttpClientFactory HttpClientFactory { get; }

    public EnrollmentsController(
        IHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    // GET: Enrollments/Create
    public async Task<IActionResult> Create(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        HttpClient httpClient = HttpClientFactory.CreateClient("API");
        var student = await httpClient.GetFromJsonAsync<Student>($"api/Students/{id}");

        if (student == null)
        {
            return NotFound();
        }

        var viewModel = new AddEnrollmentCommand()
        {
            StudentId = student.Id
        };

        var courses = await httpClient.GetFromJsonAsync<IEnumerable<Course>>($"api/Courses");

        ViewData["Courses"]
            = new SelectList(
                courses!.ExceptBy(
                    student.Enrollments.Select(e => e.Course.Id), c => c.Id),
                "Id",
                "Title");
        return View(viewModel);
    }

    // POST: Enrollments/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddEnrollmentCommand command)
    {
        HttpClient httpClient = HttpClientFactory.CreateClient("API");
        
        if (ModelState.IsValid)
        {
            var response = await httpClient.
                PostAsJsonAsync($"api/students/{command.StudentId}/enrollments", command);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Students", new { id = command.StudentId });
            }
        }

        var student = await httpClient.
            GetFromJsonAsync<Student>($"api/Students/{command.StudentId}");

        if (student == null)
        {
            return NotFound();
        }

        var courses = await httpClient.
            GetFromJsonAsync<IEnumerable<Course>>($"api/Courses");

        ViewData["Courses"]
            = new SelectList(
                courses!.ExceptBy(
                    student.Enrollments.Select(e => e.Course.Id), c => c.Id),
                "Id",
                "Title");

        return View(command);
    }

    // GET: Enrollments/Delete/5?4
    public async Task<IActionResult> Delete(int? id, int? studentId)
    {
        if (id == null)
        {
            return NotFound();
        }

        if (studentId == null)
        {
            return NotFound();
        }
        HttpClient httpClient = HttpClientFactory.CreateClient("API");
        var student = await httpClient.
            GetFromJsonAsync<Student>($"api/Students/{studentId}/enrollments/{id}");
        if (student == null)
        {
            return NotFound();
        }

        return View(student.Enrollments.FirstOrDefault());
    }

    // POST: Enrollments/Delete/5?4
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id, int? studentId)
    {
        if (id == null)
        {
            return NotFound();
        }

        if (studentId == null)
        {
            return NotFound();
        }
        HttpClient httpClient = HttpClientFactory.CreateClient("API");
        var response = await httpClient.
            DeleteAsync($"api/students/{studentId}/enrollments/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Details", "Students", new { id = studentId });
        }
        return NotFound();
    }
}
