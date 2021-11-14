using Conference.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Models
{
    public class WorkshopDto
    {
        public int ID { get; set; }
        [DisplayName("Workshop Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PlacesAvailable { get; set; }
        public string RegistrationLink { get; set; }
        public bool Active { get; set; }
        public bool RegistrationOpened { get; set; }
        public string Prerequisites { get; set; }
        public string ShortDescription { get; set; }

        public ICollection<Speaker> Speakers { get; set; }
    }
}
