using DataService.Models;

namespace HtmxMVCApp.Models;

public class StudentPageViewModel
{
    public string? Part { get; set; }
    public Student FormStudent { get; set; } = new();
    public IEnumerable<Student> Students { get; set; } = Array.Empty<Student>();
}
