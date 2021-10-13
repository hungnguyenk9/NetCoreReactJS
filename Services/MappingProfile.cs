using AutoMapper;
using NetCoreReactJS.DTO;
using NetCoreReactJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReactJS.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VoteItemDTO, VoteItem>();
            CreateMap<VoteItem, VoteItemDTO> ();
            CreateMap<Staff, StaffAddDTO>();
            CreateMap<StaffAddDTO, Staff>();
        }
    }
}
