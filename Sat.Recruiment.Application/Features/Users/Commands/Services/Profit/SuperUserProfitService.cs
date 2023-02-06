using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Commands.Services.Profit
{
    public class SuperUserProfitService : IUserProfit
    {
        const decimal PERCENTAGE_MAX_100 = 0.2M;
        public Task<UserDto> GetMoneyProfitAsync(UserDto user)
        {
            var task = Task.Run(() => {
                decimal _percentage = 0;

                if (user.Money > 100)
                {
                    _percentage = PERCENTAGE_MAX_100;
                    var gif = user.Money * _percentage;
                    user.Money = user.Money + gif;
                }

                return user;
            });

            return task;
        }
    }
}
