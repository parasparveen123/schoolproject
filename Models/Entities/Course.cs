using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models.Entities
{
    [Table("Courses")]
    public class Course
    {
        [Column("CourseId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("Title")]
        public string Title { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
