using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinanceCollege.Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeacherID { get; set; }
        public string TeacherName { get; set; }
        public DateTime TeacherBirthday { get; set; }
        public double Salary { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
