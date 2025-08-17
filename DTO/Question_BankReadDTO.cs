namespace Exam_Api_v2.DTO
{
    public class Question_BankReadDTO
    {
        public int Question_Bank_ID { get; set; }
        public string Question_Text { get; set; }
        public decimal Mark { get; set; }
        public string Correct_Answer { get; set; }
        public int Account_ID { get; set; }
        public string TeacherName { get; set; } // اسم المعلم
        public int Question_Type_ID { get; set; }
        public string QuestionTypeName { get; set; } // اسم نوع السؤال
        public int? Option_ID { get; set; } // Optional for MCQ
        public ICollection<Fill_In_GapsReadDto> Fill_In_Gaps { get; set; }
    }
}
