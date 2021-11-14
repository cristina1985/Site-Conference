using AutoMapper;
using Conference.Domain;
using Conference.Services;
using Microsoft.AspNetCore.Mvc;
using SIIT_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkshopsController : Controller
    {
        private readonly IWorkshopService service;
        private readonly IMapper mapper;

        public WorkshopsController(IWorkshopService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<Workshop> allWorkshops = service.GetAllWorkshops();


            var workshopDtos = mapper.Map<IEnumerable<WorkshopDto>>(allWorkshops);

            //foreach (var item in allSpeakers)
            //{
            //    SpeakerDto speakerDto = new SpeakerDto();
            //    speakerDto.Company = item.Company;
            //    speakerDto.FirstName = item.FirstName;
            //    speakerDtos.Add(speakerDto);
            //}

            return View(workshopDtos);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            WorkshopDto model = new WorkshopDto();

            if (id.HasValue)
            {
                var existingWorkshop = service.GetWorkshopById(id.Value);
                if (existingWorkshop != null)
                {
                    model = mapper.Map<WorkshopDto>(existingWorkshop);
                }
            }

            return View(model);
        }



        [HttpPost]
        public IActionResult Edit(WorkshopDto incomingModel)
        {
            if (incomingModel.ID > 0)
            {
                if (ModelState.IsValid)
                {

                    //1.tranform SpeakerDto in Speaker
                    var workshopInDb = new Workshop();
                    workshopInDb = mapper.Map<Workshop>(incomingModel);
                    //call the service to update the speakerInDb
                    service.Update(workshopInDb);
                    //save the entity
                    service.Save();

                    return RedirectToAction("List", "Workshops");
                }
            }

            return View(incomingModel);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new WorkshopDto();
            return View(model);
        }


        
        [HttpPost]
        public IActionResult Create(WorkshopDto model)
        {
            if (ModelState.IsValid)
            {
                //create a new Speaker
                Workshop newWorkshop = new Workshop();
                newWorkshop = mapper.Map<Workshop>(model);
                service.Add(newWorkshop);

                //save Speaker
                service.Save();
                //redirect to list
                return RedirectToAction("List", "Workshops");
            }
            return View(model);
        }


        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var existingWorkshop = service.GetWorkshopById(id);
            if (existingWorkshop != null)
            {
                service.Delete(existingWorkshop);
                service.Save();
            }

            return RedirectToAction("List", "Workshops");
        }
    }
}
