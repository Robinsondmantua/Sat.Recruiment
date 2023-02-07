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
        const decimal DUPLICATED_BENEFIT = 2.0M;

        public async Task<decimal> GetMoneyProfitAsync(decimal money)
        {
            var task = Task.Run(() =>
            {
                if (money > 100)
                {
                    var gif = money * DUPLICATED_BENEFIT;
                    money = money + gif;
                }

                return money;
            });

            return await task;
        }
    }
}
