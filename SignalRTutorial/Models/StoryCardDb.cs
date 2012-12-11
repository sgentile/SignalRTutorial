using System.Data.Entity;

namespace SignalRTutorial.Models
{
    public class StoryCardDb : DbContext
    {
        public DbSet<StoryCard> StoryCards { get; set; } 
    }
}