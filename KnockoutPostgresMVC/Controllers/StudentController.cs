using Microsoft.AspNetCore.Mvc;
using DataService.Models;
using DataService.Service;

namespace KnockoutPostgresMVC.Controllers;

public class StudentController (IStudentRepo _studentService): Controller
{
    // GET
    public IActionResult StudentView()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetAllAsync();
        return Json(students);
    }

    // POST: /Student/Create
    [HttpPost] 
    public async Task<IActionResult> Create([FromBody]Student student)
    {
        await _studentService.AddAsync(student);
        return Ok();
    }
    // POST: /Student/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit([FromBody]Student student)
    {
        await _studentService.UpdateAsync(student);
        return Ok();
    }
    // POST: /Student/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentService.DeleteAsync(id);
        return Ok();
    }
}
