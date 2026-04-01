using Microsoft.EntityFrameworkCore;
using DataService.Data;
using DataService.Models;

namespace DataService.Service;

public class StudentRepo(AppDbContext _context):IStudentRepo
{
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        var list = await _context.Students.ToListAsync();
        return list.OrderBy(x => x.Id);
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task AddAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    } 
}