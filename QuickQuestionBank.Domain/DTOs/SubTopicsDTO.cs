using QuickQuestionBank.Domain.Entities;

namespace QuickQuestionBank.Domain.DTOs
{
    public class SubTopicsDTO
    {
        public Guid? Id { get; set; }

        public Guid? TopicId { get; set; }
        public string SubTopicName { get; set; }
        public string TopicName { get; set; }

        public static void MapDtoToEntity(SubTopicsDTO source, SubTopics destination)
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
            destination.TopicId = source.TopicId;
            destination.SubTopicName = source.SubTopicName;
            destination.IsDeleted = false;
        }

        public static void MapEntityToDto(SubTopics source, SubTopicsDTO destination)
        {
            //Map using automapper or custom mapper
           destination.Id = source.Id;
            destination.TopicId = source.TopicId;
            destination.SubTopicName = source.SubTopicName;
            destination.TopicName = source.TopicName;
        }
    }
}
