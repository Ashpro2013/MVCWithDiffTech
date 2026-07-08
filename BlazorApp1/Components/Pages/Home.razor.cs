using DataService.Models;

namespace BlazorApp1.Components.Pages;

public partial class Home
{
    private Student Form { get; set; } = new();
    List<Student> filteredStudents = new List<Student>();
    protected override async Task OnInitializedAsync()
    {
        filteredStudents = (await studentrepo.GetAllAsync()).ToList();
    }

    private async Task Save()
    {
        try{
            if (Form.Id == 0)
            {
                await studentrepo.AddAsync(Form); 
            }
            else
            {
                await studentrepo.UpdateAsync(Form);

            }
            await ResetForm();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task ResetForm()
    {
        Form = new Student();
        filteredStudents = (await studentrepo.GetAllAsync()).ToList();
    }

    private async Task Remove(int id)
    {
        await studentrepo.DeleteAsync(id);
        await ResetForm();
    }

    private void SelectStudent(Student student)=>  Form = student;
}