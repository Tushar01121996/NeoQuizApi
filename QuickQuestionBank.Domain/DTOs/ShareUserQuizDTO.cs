using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.DTOs
{
    public class ShareUserQuizDTO
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }

        public Guid? QuizId { get; set; }

        public string Link { get; set; }

        public static void MapDtoToEntity(ShareUserQuizDTO source, ShareUserQuiz destination)
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

        public static void MapEntityToDto(ShareUserQuiz source, ShareUserQuizDTO destination)
        {
            //Map using automapper or custom mapper
            destination.Id = source.Id;
            destination.UserId = source.UserId;
            destination.QuizId = source.QuizId;
            destination.Link = source.Link;
        }



    }
}
