using Microsoft.EntityFrameworkCore;
using StudentsApiMangment.DataContext;
using StudentsApiMangment.Interface;
using StudentsApiMangment.Models;

namespace StudentsApiMangment.Services
{
    public class StudentService:IStudent
    {
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.students.FindAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
