using DataService.Models;

namespace DataService.Service;

public interface IStudentRepo
{
    Task<IEnumerable<Student>> GetAllAsync();
    Task<Student?> GetByIdAsync(int id);
    Task AddAsync(Student student);
    Task UpdateAsync(Student student);
    Task DeleteAsync(int id); 
}