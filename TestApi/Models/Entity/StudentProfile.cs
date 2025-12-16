using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApi.Models.Entity
{
    public class StudentProfile
    {
        [Key]
        [ForeignKey("Student")]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FiscalCode { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public Student Student { get; set; }

    }
}
