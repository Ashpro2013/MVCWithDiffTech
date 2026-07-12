using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataService.Models;
using DataService.Service;

namespace RazorPageApp.Pages;

public class StudentModel(IStudentRepo _studentRepo) : PageModel
{

    [BindProperty]
    public Student Form { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string SearchQuery { get; set; } = string.Empty;

    public IList<Student> Students { get; set; } = new List<Student>();

    public async Task OnGetAsync(int? id)
    {
        if (id.HasValue && id.Value > 0)
        {
            Form = await _studentRepo.GetByIdAsync(id.Value) ?? new Student();
        }
        else
        {
            Form = new Student();
        }

        var allStudents = await _studentRepo.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(SearchQuery))
        {
            var query = SearchQuery.Trim().ToLowerInvariant();
            Students = allStudents.Where(student =>
                student.Id.ToString().Contains(query)
                || (student.Name?.ToLowerInvariant().Contains(query) ?? false)
                || student.Age.ToString().Contains(query)
                || (student.Address?.ToLowerInvariant().Contains(query) ?? false)
                || (student.Phone?.ToLowerInvariant().Contains(query) ?? false)
            ).ToList();
        }
        else
        {
            Students = allStudents.ToList();
        }
    }

    public async Task<IActionResult> OnPostSaveAsync()
    {
        if (Form.Id == 0)
        {
            await _studentRepo.AddAsync(Form);
        }
        else
        {
            await _studentRepo.UpdateAsync(Form);
        }

        return RedirectToPage(new { searchQuery = SearchQuery });
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        await _studentRepo.DeleteAsync(id);
        return RedirectToPage(new { searchQuery = SearchQuery });
    }

    public IActionResult OnPostCancel() => RedirectToPage(new { searchQuery = SearchQuery });
}
