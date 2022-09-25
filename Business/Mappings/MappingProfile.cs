using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos.AppUser;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<AppUser, AppUserDto>().AfterMap((au,aud)=>aud.AppUserTypeName=au.AppUserType.AppUserTypeName).ReverseMap();
            
            CreateMap<AppUser, AppUserAddDto>().ReverseMap();

            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();

            CreateMap<AppUserDto, AppUserUpdateDto>().ReverseMap();
        }
    }
}
