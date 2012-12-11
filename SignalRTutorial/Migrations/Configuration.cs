using SignalRTutorial.Models;

namespace SignalRTutorial.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalRTutorial.Models.StoryCardDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SignalRTutorial.Models.StoryCardDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Database.ExecuteSqlCommand("delete from StoryCards"); //clear all the data
            context.StoryCards.AddOrUpdate(new StoryCard
                {
                    Id = 0,
                    Title = "Initial Story Card",
                    Description = "Initial story card seeded with database",
                    State = StoryState.Todo
                });
        }
    }
}
