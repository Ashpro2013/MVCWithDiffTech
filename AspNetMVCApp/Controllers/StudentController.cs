using Microsoft.AspNetCore.Mvc;
using DataService.Models;
using DataService.Service;

namespace AspNetMVCApp.Controllers;

public class StudentController(IStudentRepo studentService) : Controller
{
    public IActionResult StudentView()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await studentService.GetAllAsync();
        return Json(students);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Student student)
    {
        await studentService.AddAsync(student);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromBody] Student student)
    {
        await studentService.UpdateAsync(student);
        return Ok();
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await studentService.DeleteAsync(id);
        return Ok();
    }
}

