using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Commands.Request
{
    public class NewUserRequest : BaseRequestService<UserDto>, IRequest<UserDto>
    {
        public NewUserRequest(UserDto requestParams)
        {
            RequestParams = requestParams;
        }
    }
}
