using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SignalRTutorial.Models;

namespace SignalRTutorial.Controllers
{
    public class StoryCardController : ApiController
    {
        private StoryCardDb db = new StoryCardDb();

        // GET api/StoryCard
        public IEnumerable<StoryCard> GetStoryCards()
        {
            return db.StoryCards.AsEnumerable();
        }

        // GET api/StoryCard/5
        public StoryCard GetStoryCard(int id)
        {
            StoryCard storycard = db.StoryCards.Find(id);
            if (storycard == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return storycard;
        }

        // PUT api/StoryCard/5
        public HttpResponseMessage PutStoryCard(int id, StoryCard storycard)
        {
            if (ModelState.IsValid && id == storycard.Id)
            {
                db.Entry(storycard).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/StoryCard
        public HttpResponseMessage PostStoryCard(StoryCard storycard)
        {
            if (ModelState.IsValid)
            {
                db.StoryCards.Add(storycard);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, storycard);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = storycard.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/StoryCard/5
        public HttpResponseMessage DeleteStoryCard(int id)
        {
            StoryCard storycard = db.StoryCards.Find(id);
            if (storycard == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.StoryCards.Remove(storycard);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, storycard);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}