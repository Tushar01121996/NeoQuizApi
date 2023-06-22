using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.DTOs
{
    public class QuestionOptionViewModelDTO
    {
        public Guid QuizId { get; set; }
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string SortOrder { get; set; }
        public List<QuestionAnswerMapping> Options { get; set; }


        #region Mappers
        public static void MapDtoToEntity(QuestionOptionViewModelDTO source, QuestionOptionViewModel destination)
        {
            //Map using automapper or custom mapper
            
            destination.QuizId = source.QuizId;
            destination.QuestionId = source.QuestionId;
            destination.QuestionText = source.QuestionText;
            destination.SortOrder = source.SortOrder;
            destination.Options = source.Options;
        }
        public static void MapEntityToDto(QuestionOptionViewModel source, QuestionOptionViewModelDTO destination)
        {
            //Map using automapper or custom mapper
            //QuizDTO quizDTO = new() {
            destination.QuizId = source.QuizId;
            destination.QuestionId = source.QuestionId;
            destination.QuestionText = source.QuestionText;
            destination.SortOrder = source.SortOrder;
            destination.Options = source.Options;
        }
        #endregion
    }
}
