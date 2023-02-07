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
        public async Task<decimal> GetMoneyProfitAsync(decimal money)
        {
            var task = Task.Run(() => {
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
            });

            return await task;
        }
    }
}
