using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models.Entities
{
    [Table("Students")]
    public class Student
    {
        [Column("StudentId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("FullName")]
        public string FullName { get; set; }
         
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
