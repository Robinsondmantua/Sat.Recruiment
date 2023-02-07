using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Abstractions
{
    public interface IUserType
    {
        Task<NewUserDto> Create(NewUserDto userDto);
    }
}
