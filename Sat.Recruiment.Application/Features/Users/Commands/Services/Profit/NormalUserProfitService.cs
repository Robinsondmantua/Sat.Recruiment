using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Commands.Services.Profit
{
    internal class NormalUserProfitService : IUserProfit
    {
        const decimal PERCENTAGE_MAX_100 = 0.12M;
        const decimal PERCENTAGE_BETWEEN_10_AND_100 = 0.8M;
        public async Task<UserDto> GetMoneyProfitAsync(UserDto user)
        {
            var task = Task.Run(() => {
                decimal percentage = 0;
                if (user.Money > 100)
                {
                    percentage = PERCENTAGE_MAX_100;
                }

                if (user.Money > 10 && user.Money < 100)
                {
                    percentage = PERCENTAGE_BETWEEN_10_AND_100;
                }

                var gif = user.Money * percentage;
                user.Money = user.Money + gif;

                return user;
            });

            return await task;
        }
    }
}
