using Exam_Api_v2.Data;
using Exam_Api_v2.DTOs;
using Exam_Api_v2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Exam_Api_v2.Repo.Exam
{
    public class QuestionRepo : IQuestionRepo
    {
        private readonly AppDbContext _context;

        public QuestionRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteQuestion(int id)
        {
            var questiontoDelete = await _context.Questions.FindAsync(id);
            if (questiontoDelete == null)
            {
                // You can throw an exception, return a specific status, or log a message
                // depending on how you want to handle cases where the exam isn't found.
                throw new KeyNotFoundException($"Exam with ID {id} not found.");
            }

            _context.Questions.Remove(questiontoDelete);
            await _context.SaveChangesAsync();



        }
        public async Task<Question> EditQuestionAsync(Question existingQuestion, CreateQuestionDto dto)
        {
          

            if (existingQuestion == null)
            {
          
                throw new ArgumentNullException(nameof(existingQuestion), "The existing question to edit cannot be null.");
            }

          
            switch (dto.Type)
            {
                case "MCQ":
                    // Ensure the existing question is an MCQQuestion AND the DTO is a CreateMCQDto
                    if (existingQuestion is MCQQuestion mcqQuestion && dto is CreateMCQDto createMcqDto)
                    {
                        mcqQuestion.Text = createMcqDto.Text;
                        mcqQuestion.OptionA = createMcqDto.OptionA;
                        mcqQuestion.OptionB = createMcqDto.OptionB;
                        mcqQuestion.OptionC = createMcqDto.OptionC;
                        mcqQuestion.OptionD = createMcqDto.OptionD;
                        mcqQuestion.CorrectOption = createMcqDto.CorrectOption;
                    }
                    break;

                case "TrueFalse":
                    // Ensure the existing question is a TrueFalseQuestion AND the DTO is a CreateTrueFalseDto
                    if (existingQuestion is TrueFalseQuestion tfQuestion && dto is CreateTrueFalseDto createTfDto)
                    {
                        tfQuestion.Text = createTfDto.Text;
                        tfQuestion.CorrectAnswer = createTfDto.CorrectAnswer;
                    }
                 
                    break;

                case "FillInTheGaps":
                    // Ensure the existing question is a FillInTheGapsQuestion AND the DTO is a CreateFillInTheGapsDto
                    if (existingQuestion is FillInTheGapsQuestion figQuestion && dto is CreateFillInTheGapsDto createFigDto)
                    {
                        figQuestion.Text = createFigDto.Text;
                        figQuestion.CorrectAnswer = createFigDto.CorrectAnswer;
                    }
                 
                    break;

                default:
                    throw new Exception($"Invalid question type '{dto.Type}' specified in the DTO for update.");
            }


            // 2. Save changes to the database
            await _context.SaveChangesAsync();

            return existingQuestion;




        }

    }
}

