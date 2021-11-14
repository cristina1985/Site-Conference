using AutoMapper;
using Conference.Domain;
using SIIT_Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIIT_Conference.Infrastructure
{
    public class SpeakerMapping : Profile
    {
        public SpeakerMapping()
        {
            CreateMap<Speaker, SpeakerDto>();
        }
    }
}
