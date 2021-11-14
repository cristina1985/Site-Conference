using Conference.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface ITalkRepository
    {
        Talk Add(Talk newTalk);
        bool Delete(Talk talkToDelete);
        IEnumerable<Talk> GetAllTalks();
        Talk GetTalk(int id);
        int Save();
        Talk UpdateTalk(Talk talk);
    }

    public class TalkRepository : ITalkRepository
    {
        private readonly ConfContext context;

        public TalkRepository(ConfContext context)
        {
            this.context = context;
        }

        public IEnumerable<Talk> GetAllTalks()
        {
            return context.Talks.Include(x => x.Speakers).ToList();
        }

        public Talk GetTalk(int id)
        {
            return context.Talks.Find(id);
        }

        public Talk UpdateTalk(Talk talk)
        {
            return context.Update(talk).Entity;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Talk Add(Talk newTalk)
        {
            return context.Add(newTalk).Entity;

        }

        public bool Delete(Talk talkToDelete)
        {
            var deletedTalk = context.Remove(talkToDelete).Entity;
            if (deletedTalk != null)
            {
                return true;
            }
            return false;
        }
    }
}
