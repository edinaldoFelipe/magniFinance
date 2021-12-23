using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinanceCollege.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentBirthday { get; set; }
        public int RegisterNumber { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
