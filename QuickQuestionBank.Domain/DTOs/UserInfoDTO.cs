using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.DTOs
{
    public class UserInfoDTO
    {
        public Guid? Id { get; set; }
        // public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Guid? QuizId { get; set; }
        public static void MapDtoToEntity(UserInfoDTO source, UserInfo destination)
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
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.Email = source.Email;
            destination.QuizId = source.QuizId;
            destination.IsDeleted = false;
        }

        public static void MapEntityToDto(UserInfo source, UserInfoDTO destination)
        {
            //Map using automapper or custom mapper
            destination.Id = source.Id;
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.Email = source.Email;
            destination.QuizId=source.QuizId;
        }
    }
}

