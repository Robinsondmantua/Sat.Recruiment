using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Services
{
    internal class NormalUserWriteService : IUserType
    {
        const decimal PERCENTAGE_MAX_100 = 0.12M;
        const decimal PERCENTAGE_BETWEEN_10_AND_100 = 0.8M;
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
            }

            if (money > 10 && money < 100)
            {
                percentage = PERCENTAGE_BETWEEN_10_AND_100;
            }

            var gif = money * percentage;
            money = money + gif;
            return money;
        }
    }
}
