namespace Exam_Api_v2.DTO
{
    // DTO لقراءة بيانات سؤال الامتحان (Read)
    public class Exam_QuestionBankReadDTO
    {
        public int Exam_QB_ID { get; set; }
        public decimal Mark { get; set; }
        public int Exam_ID { get; set; }
        public string ExamTitle { get; set; } // عنوان الامتحان
        public int Question_Bank_ID { get; set; }
        public string Question { get; set; } // نص السؤال
        public int Account_ID { get; set; }
        public string TeacherName { get; set; } // اسم المعلم
    }
}
