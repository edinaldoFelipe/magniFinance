using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinanceCollege.Models
{

    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public int TeacherID { get; set; }
        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
