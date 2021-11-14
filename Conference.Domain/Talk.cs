using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Conference.Domain
{
    public partial class Talk
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public bool Active { get; set; }
        public bool FeedbackEnabled { get; set; }

        public int SpeakerID { get; set; }
        public virtual Speaker Speakers { get; set; }
    }
}
