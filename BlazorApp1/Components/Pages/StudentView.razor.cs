using DataService.Models;
using DataService.Service;
namespace BlazorApp1.Components.Pages;
public partial class StudentView(IStudentRepo _studentRepo)
{
    private Student Form { get; set; } = new();
    private List<Student> _students = new();
    private string SearchQuery { get; set; } = string.Empty;
    private IEnumerable<Student> FilteredStudents => string.IsNullOrWhiteSpace(SearchQuery) ? _students : _students.Where(student =>
            student.Id.ToString().Contains(SearchQuery.Trim(), StringComparison.OrdinalIgnoreCase)
            || (student.Name?.Contains(SearchQuery.Trim(), StringComparison.OrdinalIgnoreCase) ?? false)
            || student.Age.ToString().Contains(SearchQuery.Trim(), StringComparison.OrdinalIgnoreCase)
            || (student.Address?.Contains(SearchQuery.Trim(), StringComparison.OrdinalIgnoreCase) ?? false)
            || (student.Phone?.Contains(SearchQuery.Trim(), StringComparison.OrdinalIgnoreCase) ?? false));
    protected override async Task OnInitializedAsync() => _students = (await _studentRepo.GetAllAsync()).ToList();
    private async Task Save()
    {
        try
        {
            if (Form.Id == 0)
                await _studentRepo.AddAsync(Form);
            else
                await _studentRepo.UpdateAsync(Form);
            await ResetForm();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
    private async Task ResetForm()
    {
        Form = new Student();
        _students = (await _studentRepo.GetAllAsync()).ToList();
    }
    private async Task Remove(int id)
    {
        await _studentRepo.DeleteAsync(id);
        await ResetForm();
    }
    private void SelectStudent(Student student) => Form = student;
}