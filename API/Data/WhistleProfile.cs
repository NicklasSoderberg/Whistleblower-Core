using API.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class WhistleProfile : Profile
    {
        public WhistleProfile()
        {
            this.CreateMap<Whistle, DtoWhistle>();
            this.CreateMap<DtoWhistle, Whistle>();
        }
    }
}
