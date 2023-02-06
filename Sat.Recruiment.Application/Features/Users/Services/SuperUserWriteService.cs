using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Services
{
    internal class SuperUserWriteService : IUserType
    {
        const decimal PERCENTAGE_MAX_100 = 0.2M;
        public async Task<UserDto> Create(UserDto userDto)
        {
            throw new NotImplementedException();
        }
        private decimal GetBenefit(decimal money)
        {
            decimal percentage = 0;
            
            if (money > 100)
            {
                percentage = PERCENTAGE_MAX_100;
                var gif = money * percentage;
                money = money + gif;
            }

            return money;
        }
    }
}