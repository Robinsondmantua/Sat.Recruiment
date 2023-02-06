using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sat.Recruiment.Application.Features.Users.Dto;

namespace Sat.Recruiment.Application.Features.Users.Request
{
    public class UserRequestService : BaseRequestService<UserDto>, IRequest<UserDto>
    {
        public UserRequestService(UserDto requestParams)
        {
            RequestParams = requestParams;
        }
    }
}
