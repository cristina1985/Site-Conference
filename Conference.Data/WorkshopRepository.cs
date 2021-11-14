using Conference.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conference.Data
{
    public interface IWorkshopRepository
    {
        Workshop Add(Workshop newWorkshop);
        bool Delete(Workshop workshopToDelete);
        IEnumerable<Workshop> GetAllWorkshops();
        Workshop GetWorkshop(int id);
        int Save();
        Workshop UpdateWorkshop(Workshop workshop);
    }
    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly ConfContext context;

        public WorkshopRepository(ConfContext context)
        {
            this.context = context;
        }

        public IEnumerable<Workshop> GetAllWorkshops()
        {
            return context.Workshops.ToList();
        }

        public Workshop GetWorkshop(int id)
        {
            return context.Workshops.Find(id);
        }

        public Workshop UpdateWorkshop(Workshop workshop)
        {
            return context.Update(workshop).Entity;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Workshop Add(Workshop newWorkshop)
        {
            return context.Add(newWorkshop).Entity;

        }

        public bool Delete(Workshop workshopToDelete)
        {
            var deletedWorkshop = context.Remove(workshopToDelete).Entity;
            if (deletedWorkshop != null)
            {
                return true;
            }
            return false;
        }
    }
}

