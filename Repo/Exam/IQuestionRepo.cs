using Exam_Api_v2.DTOs;
using Microsoft.AspNetCore.Components;
using Exam_Api_v2.Models;

namespace Exam_Api_v2.Repo.Exam
{
    public interface IQuestionRepo
    {
        

        

        Task DeleteQuestion(int id);

        //()
        Task<Question> EditQuestionAsync(Question existingQuestion, CreateQuestionDto dto);
    }
}
