using Microsoft.EntityFrameworkCore;

namespace SinifCoreWebAPI.Models
{
    public class StudentContext : DbContext //dbContext inherit ettik
    {
        public StudentContext (DbContextOptions<StudentContext>options): base(options) // constructor
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
