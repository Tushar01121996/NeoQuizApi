using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.DTOs
{
    public class QuizQuestionMappingDTO
    {
        public Guid? Id { get; set; }
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }

        public string QuestionText { get; set; }
        public string SortOrder { get; set; }
        public string QuestionTypeId { get; set; }
        public Guid OptionId { get; set; }
        public string OptionText { get; set; }
        public string IsCorrectAnswer { get; set; }
        public int OptionSortOrder { get; set; }


        #region Mappers
        public static void MapDtoToEntity(QuizQuestionMappingDTO source, QuizQuestionMapping destination)
        {
            //Map using automapper or custom mapper
            if (source.Id == null)
            {
                destination.CreatedDate = DateTime.Now;
            }
            else
            {
                destination.ModifiedDate = DateTime.Now;
                destination.Id= (Guid)source.Id;
            }
            destination.QuizId = source.QuizId;
            destination.QuestionId = source.QuestionId;
            destination.QuestionText = source.QuestionText;
            destination.SortOrder = source.SortOrder;
            destination.QuestionTypeId = source.QuestionTypeId;
            destination.OptionId = source.OptionId;
            destination.OptionText = source.OptionText;
            destination.OptionSortOrder = source.OptionSortOrder;
            destination.IsCorrectAnswer = source.IsCorrectAnswer;
        }
        public static void MapEntityToDto(QuizQuestionMapping source, QuizQuestionMappingDTO destination)
        {
            //Map using automapper or custom mapper
            //QuizDTO quizDTO = new() {
            destination.Id = source.Id;
            destination.QuizId = source.QuizId;
            destination.QuestionId = source.QuestionId;
            destination.QuestionText = source.QuestionText;
            destination.SortOrder = source.SortOrder;
            destination.QuestionTypeId = source.QuestionTypeId;
            destination.OptionId = source.OptionId;
            destination.OptionText = source.OptionText;
            destination.OptionSortOrder = source.OptionSortOrder;
            destination.IsCorrectAnswer = source.IsCorrectAnswer;
        }
        #endregion
    }
}
