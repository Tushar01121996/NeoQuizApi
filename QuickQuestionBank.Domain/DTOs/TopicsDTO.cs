using QuickQuestionBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickQuestionBank.Domain.DTOs
{
    public class TopicsDTO
    {
        public Guid? Id { get; set; }
        public string TopicName { get; set; }    

        public static void MapDtoToEntity(TopicsDTO source, Topics destination)
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
            destination.TopicName = source.TopicName;
            destination.IsDeleted = false;
        }

        public static void MapEntityToDto(Topics source,TopicsDTO destination)
        {
            //Map using automapper or custom mapper
            destination.Id = source.Id;
            destination.TopicName = source.TopicName;
        }



    }
}
