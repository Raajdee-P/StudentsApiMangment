using Microsoft.EntityFrameworkCore;
using StudentsApiMangment.Models;

namespace StudentsApiMangment.DataContext
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext>options):base(options)
        {
            
        }

        public DbSet<Student>students { get; set; } 
    }

}
