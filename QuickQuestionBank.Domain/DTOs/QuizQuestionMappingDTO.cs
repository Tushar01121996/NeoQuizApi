using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.DTOs
{
    public class QuizQuestionMappingDTO
    {
        public Guid? Id { get; set; }
        public virtual Guid QuizId { get; set; }
        public virtual Guid QuestionId { get; set; }

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
        }
        public static void MapEntityToDto(QuizQuestionMapping source, QuizQuestionMappingDTO destination)
        {
            //Map using automapper or custom mapper
            //QuizDTO quizDTO = new() {
            destination.Id = source.Id;
            destination.QuizId = source.QuizId;
            destination.QuestionId = source.QuestionId;
        }
        #endregion
    }
}
