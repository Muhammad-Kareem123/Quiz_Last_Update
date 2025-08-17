using Exam_Api_v2.DTO;

using Exam_Api_v2.Models;

namespace Exam_Api_v2.Converters
{
    public static class FillInGapsConverters
    {
        // Convert من Entity إلى ReadDTO
        public static Fill_In_GapsReadDto ToReadDTO(this Fill_In_Gaps fillInGaps)
        {
            return new Fill_In_GapsReadDto
            {
                Gap_ID = fillInGaps.Gap_ID,
                Gap_Text = fillInGaps.Gap_Text,
                Correct_Answer = fillInGaps.Correct_Answer,
                Question_Bank_ID = fillInGaps.Question_Bank_ID,
                Question = fillInGaps.Question_Bank?.Question_Text // افترض وجود خاصية Question في Question_Bank
            };
        }

        // Convert من CreateDTO إلى Entity
        public static Fill_In_Gaps ToEntity(this Fill_In_GapsCreateDTO dto)
        {
            return new Fill_In_Gaps
            {
                Gap_Text = dto.Gap_Text,
                Correct_Answer = dto.Correct_Answer,
                Question_Bank_ID = dto.Question_Bank_ID
            };
        }

        // Update Entity من UpdateDTO
        public static void UpdateFromDTO(this Fill_In_Gaps fillInGaps, Fill_In_GapsUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Gap_Text))
                fillInGaps.Gap_Text = dto.Gap_Text;

            if (!string.IsNullOrWhiteSpace(dto.Correct_Answer))
                fillInGaps.Correct_Answer = dto.Correct_Answer;

            if (dto.Question_Bank_ID.HasValue)
                fillInGaps.Question_Bank_ID = dto.Question_Bank_ID.Value;
        }
    }
}
