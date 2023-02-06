using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Commands.Services.Profit
{
    public class PremiumUserProfitService : IUserProfit
    {
        const decimal DUPLICATE_BENEFIT = 2.0M;

        public async Task<UserDto> GetMoneyProfitAsync(UserDto user)
        {
            var task = Task.Run(() =>
            {
                if (user.Money > 100)
                {
                    var gif = user.Money * DUPLICATE_BENEFIT;
                    user.Money = user.Money + gif;
                }

                return user;
            });

            return await task;
        }
    }
}
