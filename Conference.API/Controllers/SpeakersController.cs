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
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService speakerService;

        public SpeakersController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }

        // GET: api/<SpeakersController>
        [HttpGet]
        public IEnumerable<Speaker> Get()
        {
            return speakerService.GetAllSpeakers();
        }

        // GET api/<SpeakersController>/5
        [HttpGet("{id}")]
        public Speaker Get(int id)
        {
            return speakerService.GetSpeakerById(id);
        }

        // POST api/<SpeakersController>
        [HttpPost]
        public IActionResult CreateSpeaker([FromBody] Speaker newSpeaker)
        {
            speakerService.Add(newSpeaker);
            speakerService.Save();
            return Ok(newSpeaker);
        }

        // PUT api/<SpeakersController>/5
        [HttpPut]
        public IActionResult UpdateSpeaker([FromBody] Speaker speaker)
        {
            Speaker existingSpeaker= speakerService.GetSpeakerById((int)speaker.ID);
            if (existingSpeaker != null)
            {
                //speakerService.Update(speaker);
                existingSpeaker.Active = speaker.Active;
                existingSpeaker.Company = speaker.Company;
                existingSpeaker.FirstName = speaker.FirstName;
                existingSpeaker.LastName = speaker.LastName;
                existingSpeaker.JobTitle = speaker.JobTitle;
                existingSpeaker.Talks = speaker.Talks;
                speakerService.Save();
                return Ok($"Speaker id: {speaker.ID} updated.");
            }
            else
                speaker.ID = 0;
                speakerService.Add(speaker);
                speakerService.Save();
                return Created($"Speaker created: {speaker.ID}", speaker);
         }

        // DELETE api/<SpeakersController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSpeaker(int id)
        {
            Speaker speakerToDelete = speakerService.GetSpeakerById(id);
            if (speakerToDelete != null)
            {
                speakerService.Delete(speakerToDelete);
                speakerService.Save();
                return Ok($"Speaker with id:{id} was deleted.");
            }
            else
                return NotFound();
           // speakerService.Delete(speakerToDelete);
        }
    }
}
