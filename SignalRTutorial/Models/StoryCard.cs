using System.Runtime.Serialization;
using SignalRTutorial.Hubs;

namespace SignalRTutorial.Models
{
    [DataContract]
    public class StoryCard
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public StoryState State { get; set; }
        [DataMember]
        public int Id { get; set; }

        public static StoryCard Create(string title, string description, StoryState storyState)
        {
            return new StoryCard
                {
                    Id = 1,
                    Title = title,
                    Description = description,
                    State = storyState
                };
        }
    }

    public enum StoryState { Todo, InProgress, Verify, Done }
}