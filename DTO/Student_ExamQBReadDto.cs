namespace Exam_Api_v2.DTO
{
    public class StudentExamQBReadDTO
    {
        public int Student_QB { get; set; }
        public string StudentAnswer { get; set; }
        public int Account_ID { get; set; }
        public string StudentName { get; set; } // Optional: Include student name if needed
        public int Exam_QB_ID { get; set; }
    }
}
