using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.DTOs
{
    public class UserQuizAttemptDTO
    {
        
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? QuizId { get; set; }
        public Guid? QuestionId { get; set; }
        public Guid? OptionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public static void MapDtoToEntity(UserQuizAttemptDTO source, UserQuizAttempt destination)
        {
            destination.Id = (Guid)source.Id;
            destination.CreatedDate = DateTime.Now;
            destination.UserId = source.UserId;
            destination.QuizId = source.QuizId;
            destination.QuestionId = source.QuestionId;
            destination.OptionId = source.OptionId;
            destination.IsDeleted = source.IsDeleted;
        }

        public static void MapEntityToDto(UserQuizAttempt source, UserQuizAttemptDTO destination)
        {
            //Map using automapper or custom mapper
            destination.UserId = source.UserId;
            destination.QuizId = source.QuizId;
            destination.QuestionId = source.QuestionId;
            destination.OptionId = source.OptionId;
            destination.IsDeleted = source.IsDeleted;
            destination.Id = source.Id;
        }



    }
}
