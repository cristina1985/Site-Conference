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
    public class TalksController : ControllerBase
    {
        private readonly ITalkService talkService;

        public TalksController(ITalkService talkService)
        {
            this.talkService = talkService;
        }
        // GET: api/<TalksController>
        [HttpGet]
        public IEnumerable<Talk> Get()
        {
            return talkService.GetAllTalks();
        }

        // GET api/<TalksController>/5
        [HttpGet("{id}")]
        public Talk Get(int id)
        {
            return talkService.GetTalkById(id);
        }

        // POST api/<TalksController>
        [HttpPost]
        public IActionResult Post([FromBody] Talk newTalk)
        {
            talkService.Add(newTalk);
            talkService.Save();
            return Ok(newTalk);
        }

        // PUT api/<TalksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Talk talkToModify)
        {
            talkToModify = talkService.GetTalkById(id);
            talkService.Update(talkToModify);
        }

        // DELETE api/<TalksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var talkToDelete = talkService.GetTalkById(id);
            if (talkToDelete != null)
            {
                talkService.Delete(talkToDelete);
                talkService.Save();
            }
        }
    }
}
