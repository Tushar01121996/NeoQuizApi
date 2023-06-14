using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.DTOs
{
    public class UserQuizDTO
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }

        public Guid? QuizId { get; set; }

        public string Link { get; set; }

        public static void MapDtoToEntity(UserQuizDTO source, UserQuiz destination)
        {
            if (source.Id == null)
            {
                destination.CreatedDate = DateTime.Now;
            }
            else
            {
                destination.ModifiedDate = DateTime.Now;
                destination.Id = (Guid)source.Id;
            }
            destination.UserId = source.UserId;
            destination.QuizId = source.QuizId;
           destination.Link = source.Link;
            destination.IsDeleted = false;
        }

        public static void MapEntityToDto(UserQuiz source, UserQuizDTO destination)
        {
            //Map using automapper or custom mapper
            destination.Id = source.Id;
            destination.UserId = source.UserId;
            destination.QuizId = source.QuizId;
           destination.Link = source.Link;
        }



    }
}
