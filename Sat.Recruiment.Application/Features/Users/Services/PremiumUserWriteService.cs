using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Services
{
    internal class PremiumUserWriteService : IUserType
    {
        const decimal DUPLICATE_BENEFIT = 2.0M;

        public async Task<UserDto> Create(UserDto userDto)
        {
            throw new NotImplementedException();
        }
        private decimal GetBenefit(decimal money)
        {
            if (money > 100)
            {
                var gif = money * DUPLICATE_BENEFIT;
                money = money + gif;
            }
            
            return money;
        }
    }
}