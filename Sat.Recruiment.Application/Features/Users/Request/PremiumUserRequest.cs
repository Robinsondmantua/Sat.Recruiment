using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Request
{
    internal class PremiumUserRequest : UserBaseHandler<UserDto>, IRequest<UserDto>
    {
        public PremiumUserRequest(UserDto requestParams)
        {
            RequestParams = requestParams;
        }
    }
}
