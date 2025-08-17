using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;
using System.Linq;
namespace Exam_Api_v2.Convertor
{
    public static class Question_BankConvertor
    {
        // Convert من Entity إلى ReadDTO
        public static Question_BankReadDTO ToReadDTO(this Question_Bank questionBank)
        {
            return new Question_BankReadDTO
            {
                Question_Bank_ID = questionBank.Question_Bank_ID,
                Question_Text = questionBank.Question_Text,
                Mark = questionBank.Mark,
                Correct_Answer = questionBank.Correct_Answer,
                Account_ID = questionBank.Account_ID,
                TeacherName = questionBank.Teacher?.FullNameEn, // افترض وجود خاصية FullNameEn في Account
                Question_Type_ID = questionBank.Question_Type_ID,
                QuestionTypeName = questionBank.QuestionType?.QuestionType_Name, // افترض وجود خاصية Name في QuestionType
                Option_ID = questionBank.Option_ID,
                Fill_In_Gaps = questionBank.Fill_In_Gaps?.Select(f => new Fill_In_GapsReadDto
                {
                    Gap_ID = f.Gap_ID,
                    Gap_Text = f.Gap_Text,
                    Correct_Answer = f.Correct_Answer
                }).ToList() // تحويل قائمة ملء الفراغات إلى DTO
            };
        }
        public static Question_Bank ToEntity(this Question_BankCreateDTO dto)
        {
            return new Question_Bank
            {
                Question_Text = dto.Question_Text,
                Mark = dto.Mark,
                Correct_Answer = dto.Correct_Answer,
                Account_ID = dto.Account_ID,
                Question_Type_ID = dto.Question_Type_ID,
                Option_ID = (int)dto.Option_ID
            };
        }
        public static void UpdateFromDTO(this Question_Bank questionBank, Question_BankUpdateDTO dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Question_Text))
                questionBank.Question_Text = dto.Question_Text;
            if (dto.Mark.HasValue)
                questionBank.Mark = dto.Mark.Value;
            if (!string.IsNullOrWhiteSpace(dto.Correct_Answer))
                questionBank.Correct_Answer = dto.Correct_Answer;
            if (dto.Account_ID.HasValue)
                questionBank.Account_ID = dto.Account_ID.Value;
            if (dto.Question_Type_ID.HasValue)
                questionBank.Question_Type_ID = dto.Question_Type_ID.Value;
            if (dto.Option_ID.HasValue)
                questionBank.Option_ID = dto.Option_ID.Value;
        }

    }
}
