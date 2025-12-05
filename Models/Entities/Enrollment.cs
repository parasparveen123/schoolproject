using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Models.Entities
{
    [Table("Enrollments")]
    public class Enrollment
    {
        [Column("EnrollmentId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("StudentId")]
        public int StudentId { get; set; }
        
        [Column("CourseId")]
        public int CourseId { get; set; }

        [Column("EnrolledOn")]
        public DateTime EnrolledOn { get; set; }
        // Navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
