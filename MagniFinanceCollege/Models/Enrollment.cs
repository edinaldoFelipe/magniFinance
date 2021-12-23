using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinanceCollege.Models
{
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Enrollment_Subject> Enrollment_Subjects { get; set; }
    }
}
