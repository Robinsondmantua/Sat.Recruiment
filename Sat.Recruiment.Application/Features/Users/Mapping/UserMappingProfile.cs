using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sat.Recruiment.Application.Features.Users.Dto;
using Sat.Recruiment.Domain.Models;

namespace Sat.Recruiment.Application.Features.Users.Mapping
{
    /// <summary>
    /// This class is used for profiling the mapping configuration 
    /// </summary>
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, NewUserDto>().ReverseMap();
        }
    }
}
