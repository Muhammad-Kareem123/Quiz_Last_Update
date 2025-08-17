using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;
using System.Linq;

namespace Exam_Api_v2.Converters
{
    public static class QuestionTypeConverter
    {
        // Convert من Entity إلى ReadDTO
        public static Question_TypeReadDto ToReadDTO(this QuestionType questionType)
        {
            return new Question_TypeReadDto
            {
                Question_Type_ID = questionType.Question_Type_ID,
                QuestionType_Name = questionType.QuestionType_Name,
                Question_Description = questionType.Question_Description,
                Mark = questionType.Mark,
                Question_Banks = questionType.Question_Banks?.Select(q => new Question_BankReadDTO
                {
                    Question_Bank_ID = q.Question_Bank_ID,
                    Question_Text = q.Question_Text
                }).ToList() // تحويل قائمة الأسئلة إلى DTO
            };
        }

        // Convert من CreateDTO إلى Entity
        public static QuestionType ToEntity(this Question_TypeCreateDTO dto)
        {
            return new QuestionType
            {
                QuestionType_Name = dto.QuestionType_Name,
                Question_Description = dto.Question_Description,
                Mark = dto.Mark
            };
        }

        // Update Entity من UpdateDTO
        public static void UpdateFromDTO(this QuestionType questionType, Question_TypeUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.QuestionType_Name))
                questionType.QuestionType_Name = dto.QuestionType_Name;

            if (!string.IsNullOrWhiteSpace(dto.Question_Description))
                questionType.Question_Description = dto.Question_Description;

            if (dto.Mark.HasValue)
                questionType.Mark = dto.Mark.Value;
        }
    }
}
