using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;
using System.Linq;

namespace Exam_Api_v2.Converters
{
    public static class MCQOptionsConverters
    {
        public static MCQ_OptionReadDto ToReadDTO(this MCQ_Options mcqOption)
        {
            return new MCQ_OptionReadDto
            {
                Option_ID = mcqOption.Option_ID,
                Option_Text = mcqOption.Option_Text,
                Is_Correct = mcqOption.Is_Correct,
                Question_Banks = mcqOption.Question_Banks?.Select(q => new Question_BankReadDTO
                {
                    Question_Bank_ID = q.Question_Bank_ID,
                    Question_Text = q.Question_Text
                }).ToList()
            };
        }

        public static MCQ_Options ToEntity(this MCQ_OptionCreateDTO dto)
        {
            return new MCQ_Options
            {
                Option_Text = dto.Option_Text,
                Is_Correct = dto.Is_Correct
            };
        }

        public static void UpdateFromDTO(this MCQ_Options mcqOption, MCQ_OptionsUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Option_Text))
                mcqOption.Option_Text = dto.Option_Text;

            if (dto.Is_Correct.HasValue)
                mcqOption.Is_Correct = dto.Is_Correct.Value;
        }
    }
}
