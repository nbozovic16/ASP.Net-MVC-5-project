using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VidlyOrg.Dtos;
using VidlyOrg.Models;

namespace VidlyOrg.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            //
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}