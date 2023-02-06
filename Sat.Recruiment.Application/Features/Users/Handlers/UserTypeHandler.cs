using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Dto;
using Sat.Recruiment.Application.Features.Users.Request;
using Sat.Recruiment.Domain.Enums;

namespace Sat.Recruiment.Application.Features.Users.Handlers
{
    public class UserTypeHandler : IRequestHandler<UserRequestService, UserDto>
    {
        private readonly Func<UserType, IUserType> _userType;

        public UserTypeHandler(Func<UserType, IUserType> userType)
        {
            _userType = userType;
        }

        public async Task<UserDto> Handle(UserRequestService request, CancellationToken cancellationToken)
        {
            var userTypeObject = _userType(request.RequestParams.UserType);
            
            var newUser = await userTypeObject.Create(request.RequestParams);
            
            return newUser;
        }
    }
}
