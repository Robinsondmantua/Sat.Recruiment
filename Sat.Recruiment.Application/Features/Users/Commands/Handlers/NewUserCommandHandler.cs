using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sat.Recruiment.Application.Common.Abstractions;
using Sat.Recruiment.Application.Common.Exceptions;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Commands.Request;
using Sat.Recruiment.Application.Features.Users.Dto;
using Sat.Recruiment.Domain.Enums;
using Sat.Recruiment.Domain.Models;

namespace Sat.Recruiment.Application.Features.Users.Commands.Handlers
{
    public class NewUserCommandHandler : IRequestHandler<NewUserRequest, NewUserDto>
    {
        private readonly Func<UserType, IUserProfit> _userProfit;
        private readonly ICommandRepository<User> _commandRepository;
        private readonly IQueryRepository<User> _queryRepository;
        private readonly IMapper _mapper;

        public NewUserCommandHandler(Func<UserType, IUserProfit> userProfit, 
            ICommandRepository<User> commandRepository, 
            IQueryRepository<User> queryRepository,
            IMapper mapper)
        {
            _userProfit = userProfit;
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<NewUserDto> Handle(NewUserRequest request, CancellationToken cancellationToken)
        {
            var userProfitObject = _userProfit(request.RequestParams.UserType);
            var newUserProfit = await userProfitObject.GetMoneyProfitAsync(request.RequestParams.Money);

            var newUser = User.Create(request.RequestParams.Name, 
                request.RequestParams.Email, 
                request.RequestParams.Address, 
                request.RequestParams.Phone, 
                request.RequestParams.UserType,
                newUserProfit);

            var isUserDuplicated = await _queryRepository.CheckDuplicatesEntriesAsync(newUser);

            if (isUserDuplicated)
            {
                throw new DuplicateDataException("User duplicated");
            }

            var result = await _commandRepository.AddAsync(newUser);
            return _mapper.Map<NewUserDto>(result);
        }
    }
}
