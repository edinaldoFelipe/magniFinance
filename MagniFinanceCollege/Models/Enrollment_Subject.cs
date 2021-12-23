namespace MagniFinanceCollege.Models
{
    public enum Grade
    {
        A, B, C, D, E, F
    }

    public class Enrollment_Subject
    {
        public int EnrollmentID { get; set; }
        public int SubjectID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Enrollment Enrollments { get; set; }
    }
}
