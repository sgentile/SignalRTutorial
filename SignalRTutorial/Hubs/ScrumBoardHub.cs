using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRTutorial.Models;

namespace SignalRTutorial.Hubs
{
    public class ScrumBoardHub : Hub
    {
        private readonly IScrumRepository _repository;
        
        public ScrumBoardHub(IScrumRepository repository)
        {
            _repository = repository;
        }
        public ScrumBoardHub()
            : this(new ScrumBoardRepository())
        {

        }

        public void RemoveStory(int id)
        {
            StoryCard storyCard = _repository.Get(id);
            _repository.Delete(storyCard);
            Clients.Caller.removeStory(storyCard);
        }

        public void UpdateStory(StoryCard story)
        {
            _repository.Update(story);
            Clients.Caller.storyUpdated(story);
        }

        public void CreateStory(StoryCard story)
        {
            _repository.Create(story);
            Clients.Caller.addedStory(story);
        }

        public void GetStories()
        {
            var stories = _repository.Get();
            Clients.Caller.populateStories(stories);
        }
    }

    public interface IScrumRepository
    {
        IEnumerable<StoryCard> Get();
        StoryCard Get(int id);
        StoryCard Create(StoryCard storyCard);
        StoryCard Update(StoryCard storyCard);
        void Delete(StoryCard storyCard);
    }

    public class ScrumBoardRepository : IScrumRepository
    {
        private readonly StoryCardDb _db = new StoryCardDb();

        public IEnumerable<StoryCard> Get()
        {
            return _db.StoryCards.AsEnumerable();
        }

        public StoryCard Get(int id)
        {
            return _db.StoryCards.Find(id);
        }

        public StoryCard Create(StoryCard storyCard)
        {
            _db.StoryCards.Add(storyCard);
            _db.SaveChanges();
            return storyCard;
        }

        public StoryCard Update(StoryCard storyCard)
        {
            _db.Entry(storyCard).State = EntityState.Modified;
            _db.SaveChanges();
            return storyCard;
        }

        public void Delete(StoryCard storyCard)
        {            
            _db.StoryCards.Remove(storyCard);
            _db.SaveChanges();

        }
    }
}