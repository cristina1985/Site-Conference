using Conference.Data;
using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Services
{
    public interface IWorkshopService
    {
        Workshop Add(Workshop newWorkshop);
        bool Delete(Workshop workshop);
        IEnumerable<Workshop> GetAllActiveWorkshops();
        IEnumerable<Workshop> GetAllWorkshops();
        Workshop GetWorkshopById(int id);
        int Save();
        Workshop Update(Workshop workshopToModify);
    }
    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository repo;

        public WorkshopService(IWorkshopRepository repo)
        {
            this.repo = repo;
        }

        public IEnumerable<Workshop> GetAllWorkshops()
        {
            return repo.GetAllWorkshops();
        }

        public IEnumerable<Workshop> GetAllActiveWorkshops()
        {
            var allworkshops = repo.GetAllWorkshops();
            return allworkshops.Where(x => x.Active);

        }

        public Workshop GetWorkshopById(int id)
        {
            return repo.GetWorkshop(id);
        }

        public Workshop Update(Workshop workshopToModify)
        {
            return repo.UpdateWorkshop(workshopToModify); //in Services
        }

        public int Save()
        {
            return repo.Save();

        }

        public Workshop Add(Workshop newWorkshop)
        {
            return repo.Add(newWorkshop);
        }

        public bool Delete(Workshop workshop)
        {
            return repo.Delete(workshop);
        }
    }
}

