using Conference.Data;
using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Services
{
    public interface ITalkService
    {
        Talk Add(Talk newTalk);
        bool Delete(Talk talk);
        IEnumerable<Talk> GetAllActiveTalks();
        IEnumerable<Talk> GetAllTalks();
        Talk GetTalkById(int id);
        int Save();
        Talk Update(Talk talkToModify);
    }

    public class TalkService : ITalkService
    {
        private readonly ITalkRepository repo;
        public TalkService(ITalkRepository repo)
        {
            this.repo = repo;

        }

        public IEnumerable<Talk> GetAllTalks()
        {
            return repo.GetAllTalks();
        }

        public IEnumerable<Talk> GetAllActiveTalks()
        {
            var alltalks = repo.GetAllTalks();
            return alltalks.Where(x => x.Active);

        }

        public Talk GetTalkById(int id)
        {
            return repo.GetTalk(id);
        }

        public Talk Update(Talk talkToModify)
        {
            return repo.UpdateTalk(talkToModify); //in Services
        }

        public int Save()
        {
            return repo.Save();
        }

        public Talk Add(Talk newTalk)
        {
            return repo.Add(newTalk);
        }

        public bool Delete(Talk talk)
        {
            return repo.Delete(talk);
        }
    }
}

