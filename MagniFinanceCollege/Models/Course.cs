using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinanceCollege.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}