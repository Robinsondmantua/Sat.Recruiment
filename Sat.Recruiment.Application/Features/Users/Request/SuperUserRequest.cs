using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Request
{
    internal class SuperUserRequest : UserBaseHandler<UserDto>, IRequest<UserDto>
    {
        public SuperUserRequest(UserDto requestParams)
        {
            RequestParams = requestParams;
        }
    }
}