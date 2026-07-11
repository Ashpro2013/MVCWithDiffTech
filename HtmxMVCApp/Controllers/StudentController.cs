using Microsoft.AspNetCore.Mvc;
using DataService.Models;
using DataService.Service;
using HtmxMVCApp.Models;

namespace HtmxMVCApp.Controllers;

public class StudentController (IStudentRepo _studentService): Controller
{
    // GET: /Student/StudentView
    public IActionResult StudentView()
    {
        return View(new StudentPageViewModel { Part = "full" });
    }

    // GET: /Student/GetList
    [HttpGet]
    public async Task<IActionResult> GetList(string? searchQuery)
    {
        var students = await _studentService.GetAllAsync();
        if (!string.IsNullOrEmpty(searchQuery))
        {
            var lower = searchQuery.ToLowerInvariant();
            students = students.Where(s => 
                (s.Name != null && s.Name.ToLowerInvariant().Contains(lower)) ||
                (s.Address != null && s.Address.ToLowerInvariant().Contains(lower)) ||
                (s.Phone != null && s.Phone.ToLowerInvariant().Contains(lower)) ||
                s.Age.ToString().Contains(lower)
            ).ToList();
        }
        return PartialView("StudentView", new StudentPageViewModel { Part = "list", Students = students });
    }

    // GET: /Student/GetForm
    [HttpGet]
    public async Task<IActionResult> GetForm(int id)
    {
        Student student;
        if (id > 0)
        {
            student = await _studentService.GetByIdAsync(id) ?? new Student { Id = 0 };
        }
        else
        {
            student = new Student { Id = 0 };
        }
        return PartialView("StudentView", new StudentPageViewModel { Part = "form", FormStudent = student });
    }

    // POST: /Student/Save
    [HttpPost]
    public async Task<IActionResult> Save(Student student)
    {
        if (student.Id > 0)
        {
            await _studentService.UpdateAsync(student);
        }
        else
        {
            await _studentService.AddAsync(student);
        }
        Response.Headers["HX-Trigger"] = "studentChanged";
        return PartialView("StudentView", new StudentPageViewModel { Part = "form", FormStudent = new Student { Id = 0 } });
    }

    // POST: /Student/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentService.DeleteAsync(id);
        Response.Headers["HX-Trigger"] = "studentChanged";
        return PartialView("StudentView", new StudentPageViewModel { Part = "form", FormStudent = new Student { Id = 0 } });
    }
}
