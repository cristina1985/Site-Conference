using Conference.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Models
{
    public class TalkDto
    {
        public int ID { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public bool Active { get; set; }
        public bool FeedbackEnabled { get; set; }

        [DisplayName("Speaker Name")]
        public int SpeakerID { get; set; }
       
        public Speaker Speakers { get; set; }
    }
}
