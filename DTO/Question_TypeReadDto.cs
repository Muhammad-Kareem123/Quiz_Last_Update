namespace Exam_Api_v2.DTO
{
    public class Question_TypeReadDto
    {
        
            public int Question_Type_ID { get; set; }
            public string QuestionType_Name { get; set; }
            public string? Question_Description { get; set; }
            public decimal Mark { get; set; }
            public ICollection<Question_BankReadDTO> Question_Banks { get; set; } // قائمة الأسئلة المرتبطة
        
    }
}
