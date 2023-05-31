using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Domain.DTOs
{
    public class ShareQuizDTO
    {
        public Guid QuizId { get; set; }
        public string Email { get; set; }
        public string Link { get; set; }

        #region Mappers
        public static void MapDtoToEntity(ShareQuizDTO source, ShareQuiz destination)
        {
            //Map using automapper or custom mapper
            destination.CreatedDate = DateTime.Now;
            destination.QuizId = source.QuizId;
            destination.Email = source.Email;
            destination.Link = source.Link;
            destination.IsDeleted = false;

        }
        public static void MapEntityToDto(ShareQuiz source, ShareQuizDTO destination)
        {
            //Map using automapper or custom mapper
            //QuizDTO quizDTO = new() {
            destination.QuizId = source.QuizId;
            destination.Email = source.Email;
            destination.Link = source.Link;
        }
        #endregion
    }
}
