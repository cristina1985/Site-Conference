using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Conference.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly IWorkshopService workshopService;

        public WorkshopsController(IWorkshopService workshopService)
        {
            this.workshopService = workshopService;
        }// GET: api/<WorkshopsController>
        [HttpGet]
        public IEnumerable<Workshop> Get()
        {
            return workshopService.GetAllWorkshops();
        }

        // GET api/<WorkshopsController>/5
        [HttpGet("{id}")]
        public Workshop Get(int id)
        {
            return workshopService.GetWorkshopById(id);
        }

        // POST api/<WorkshopsController>
        [HttpPost]
        public void Post([FromBody] Workshop newWorkshop)
        {
            workshopService.Add(newWorkshop);
        }

        // PUT api/<WorkshopsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Workshop workshopToModify)
        {
            workshopToModify = workshopService.GetWorkshopById(id);
            workshopService.Update(workshopToModify);
        }

        // DELETE api/<WorkshopsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var workshopToDelete = workshopService.GetWorkshopById(id);
            if (workshopToDelete != null)
            {
                workshopService.Delete(workshopToDelete);
                workshopService.Save();
            }
        }
    }
}
