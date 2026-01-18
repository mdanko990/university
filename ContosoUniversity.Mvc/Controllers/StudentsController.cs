using ContosoUniversity.Entities;
using ContosoUniversity.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContosoUniversity.Mvc.Controllers;

public class StudentsController : Controller
{
    private IHttpClientFactory _httpClientFactory;
    private IWebHostEnvironment _environment;

    public StudentsController(IHttpClientFactory httpClientFactory, IWebHostEnvironment environment)
    {
        _httpClientFactory = httpClientFactory;
        _environment = environment;
    }

    // GET: Students
    public async Task<IActionResult> Index()
    {
        HttpClient httpClient = _httpClientFactory.CreateClient("API");
        var students = await httpClient
            .GetFromJsonAsync<IEnumerable<Student>>("api/Students");
        return View(students);
    }

    // GET: Students/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        HttpClient httpClient = _httpClientFactory.CreateClient("API");
        var student = await httpClient.
            GetFromJsonAsync<Student>($"api/Students/{id}");
        if (student == null)
        {
            return NotFound();
        }
        return View(student);
    }

    // GET: Students/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StudentViewModel studentViewModel)
    {
        if (ModelState.IsValid)
        {
            var student = new Student()
            {
                LastName = studentViewModel.LastName!,
                FirstName = studentViewModel.FirstName!,
                EnrollmentDate = studentViewModel.EnrollmentDate,
                PhotoUri = await UploadFile(studentViewModel.PhotoUri!)
            };
            var httpClient = _httpClientFactory.CreateClient("API");
            var response = await httpClient.
                PostAsJsonAsync("api/students", student);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        return View(studentViewModel);
    }

    // GET: Students/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        HttpClient httpClient = _httpClientFactory.CreateClient("API");
        var student = await httpClient.
            GetFromJsonAsync<Student>($"api/Students/{id}");

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: Students/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=31759 8.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (ModelState.IsValid)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("API");
            var response = await httpClient.
                PutAsJsonAsync($"api/students/{id}", student);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        return View(student);
    }

    // GET: Students/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        HttpClient httpClient = _httpClientFactory.CreateClient("API");
        var student = await httpClient
            .GetFromJsonAsync<Student>($"api/Students/{id}");

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: Students/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient("API");
        var response = await httpClient.
            DeleteAsync($"api/students/{id}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }

        return NotFound();
    }

    private async Task<string> UploadFile(IFormFile file)
    {
        string webRootPath = _environment.WebRootPath;
        var filePath = Path.Combine(webRootPath, "photos");
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }
        var fileName = Path.GetFileName(file.FileName);
        var copyPath = Path.Combine(filePath, fileName);
        using (var stream = new FileStream(copyPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return @$"/photos/{fileName}";
    }
}
