using QuickQuestionBank.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickQuestionBank.Domain.DTOs
{
    public class QuestionTypeDTO
    {
        public Guid? Id { get; set; }
        public string QuestionTypeName { get; set; }
       

        #region Mappers
        public static void MapDtoToEntity(QuestionTypeDTO source, QuestionType destination)
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
            destination.QuestionTypeName = source.QuestionTypeName;
        }
        public static void MapEntityToDto(QuestionType source, QuestionTypeDTO destination)
        {
            //Map using automapper or custom mapper
            //QuizDTO quizDTO = new() {
            destination.Id = source.Id;
            destination.QuestionTypeName = source.QuestionTypeName;
        }
        #endregion
    }
}
