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
    public class TalksController : Controller
    {
        private readonly ITalkService service;
        private readonly IMapper mapper;

        public TalksController(ITalkService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<Talk> allTalks = service.GetAllTalks();
            var talkDtos = mapper.Map<IEnumerable<TalkDto>>(allTalks);
            return View(talkDtos);
        }

      
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            TalkDto model = new TalkDto();

            if (id.HasValue)
            {
                var existingTalk = service.GetTalkById(id.Value);
                if (existingTalk != null)
                {
                    model = mapper.Map<TalkDto>(existingTalk);
                }
            }

            return View(model);
        }
        
        [HttpPost]
        public IActionResult Edit(TalkDto incomingModel)
        {
            if (incomingModel.ID > 0)
            {
                if (ModelState.IsValid)
                {

                    //1.transform TalkDto in Talk
                    var talkInDb = new Talk();
                    talkInDb = mapper.Map<Talk>(incomingModel);
                    //call the service to update the speakerInDb
                    service.Update(talkInDb);
                    //save the entity
                    service.Save();
                    return RedirectToAction("List", "Talks");
                }
            }
            return View(incomingModel);

        }

        
        [HttpGet]
        public IActionResult Create()
        {
            var model = new TalkDto();
            return View(model);
        }

  
        [HttpPost]
        public IActionResult Create(TalkDto model)
        {
            if (ModelState.IsValid)
            {
                //create a new Speaker
                Talk newTalk = new Talk();
                newTalk = mapper.Map<Talk>(model);
                service.Add(newTalk);

                //save Speaker
                service.Save();
                //redirect to list
                return RedirectToAction("List", "Talks");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var existingTalk = service.GetTalkById(id);
            if (existingTalk != null)
            {
                service.Delete(existingTalk);
                service.Save();
            }

            return RedirectToAction("List", "Talks");
        }
    }
}
