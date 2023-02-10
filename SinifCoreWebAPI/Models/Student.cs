
using System.ComponentModel.DataAnnotations;//key için

namespace SinifCoreWebAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string SchoolId { get; set; }

        public string Gender { get; set; }
    }
}
