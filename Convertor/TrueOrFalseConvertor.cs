using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;

namespace Exam_Api_v2.Converter
{
    public static class TrueOrFalseConvertor
    {
        public static TrueOrFalseReadDTO ToReadDTO(this TrueOrFalse trueOrFalse)
        {
            return new TrueOrFalseReadDTO
            {
                Question_Bank_ID = trueOrFalse.Question_Bank_ID,
                Correct_Ans = trueOrFalse.Correct_Ans,
                QuestionText = trueOrFalse.Question_Bank?.Question_Text // From related entity
            };
        }

        public static TrueOrFalse ToEntity(this TrueOrFalseCreateDTO dto)
        {
            return new TrueOrFalse
            {
                Question_Bank_ID = dto.Question_Bank_ID,
                Correct_Ans = dto.Correct_Ans
            };
        }

        public static void UpdateFromDTO(this TrueOrFalse trueOrFalse, TrueOrFalseUpdateDTO dto)
        {
            trueOrFalse.Correct_Ans = dto.Correct_Ans;
        }
    }
}
