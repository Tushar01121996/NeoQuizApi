using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.DTOs
{
    public class QuizQuestionDTO
    {
        public Guid? Id { get; set; }
        public string QuestionText { get; set; }
        public Guid QuestionTypeId { get; set; }

        //[ForeignKey(nameof(QuestionTypeId))]
        //public QuestionType QuestionType { get; set; }
        public decimal Marks { get; set; }
        public string SortOrder { get; set; }
        public string ComplexityLevel { get; set; }

        #region Mappers
        public static void MapDtoToEntity(QuizQuestionDTO source, QuizQuestion destination)
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
            destination.QuestionText = source.QuestionText;
            destination.ComplexityLevel = source.ComplexityLevel;
            destination.Marks = source.Marks;
            destination.SortOrder = source.SortOrder;
            destination.QuestionTypeId = source.QuestionTypeId;
        }
        public static void MapEntityToDto(QuizQuestion source, QuizQuestionDTO destination)
        {
            //Map using automapper or custom mapper
            //QuizDTO quizDTO = new() {
            destination.Id = source.Id;
            destination.QuestionText = source.QuestionText;
            destination.ComplexityLevel = source.ComplexityLevel;
            destination.Marks = source.Marks;
            destination.SortOrder = source.SortOrder;
            destination.QuestionTypeId = source.QuestionTypeId;
        }
        #endregion
    }
}
