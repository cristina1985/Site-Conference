using Conference.Data;
using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Services
{
    public interface ISpeakerService
    {
        Speaker Add(Speaker newSpeaker);
        bool Delete(Speaker speaker);
        IEnumerable<Speaker> GetAllActiveSpeakers();
        IEnumerable<Speaker> GetAllSpeakers();
        Speaker GetSpeakerById(int id);
        int Save();
        Speaker Update(Speaker speakerToModify);
        object GetSpeakerById(object value);
    }

    public class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository repo;

        public SpeakerService(ISpeakerRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Speaker> GetAllSpeakers()
        {
            return repo.GetAllSpeakers();
            //return only all Active Speakers
            //var allspeakers = repo.GetAllSpeakers();
            //return allspeakers.Where(x => x.Active);
        }
        public IEnumerable<Speaker> GetAllActiveSpeakers()
        {
            var allspeakers = repo.GetAllSpeakers();
            return allspeakers.Where(x => x.Active);

        }
        public Speaker GetSpeakerById(int id)
        {
            return repo.GetSpeaker(id);
        }

        public Speaker Update (Speaker speakerToModify)
        {
            return repo.UpdateSpeaker(speakerToModify); //in Services
        }

        public int Save()
        {
            return repo.Save();

        }

        public Speaker Add(Speaker newSpeaker)
        {
            return repo.Add(newSpeaker);
        }

        public bool Delete(Speaker speaker)
        {
            return repo.Delete(speaker);
        }

        public object GetSpeakerById(object value)
        {
            throw new NotImplementedException();
        }
    }
}
