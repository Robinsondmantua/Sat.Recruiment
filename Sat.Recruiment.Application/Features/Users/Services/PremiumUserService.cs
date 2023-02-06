using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Services
{
    internal class PremiumUserService : IUserType
    {
        public Task Create(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}