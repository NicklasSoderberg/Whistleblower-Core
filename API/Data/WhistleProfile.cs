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
            this.CreateMap<Conversation, DtoConversation>();
            this.CreateMap<DtoConversation, Conversation>();
            this.CreateMap<File, DtoFile>();
            this.CreateMap<DtoFile, File>();
            this.CreateMap<DtoLawyer, Lawyer>();
            this.CreateMap<Lawyer, DtoLawyer>();
        }
    }
}
