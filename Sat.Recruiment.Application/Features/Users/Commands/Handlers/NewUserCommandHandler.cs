using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sat.Recruiment.Application.Common.Abstractions;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Commands.Request;
using Sat.Recruiment.Application.Features.Users.Dto;
using Sat.Recruiment.Domain.Enums;
using Sat.Recruiment.Domain.Models;

namespace Sat.Recruiment.Application.Features.Users.Commands.Handlers
{
    public class NewUserCommandHandler : IRequestHandler<NewUserRequest, UserDto>
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

        public async Task<UserDto> Handle(NewUserRequest request, CancellationToken cancellationToken)
        {
            var userProfitObject = _userProfit(request.RequestParams.UserType);
            var userProfit = await userProfitObject.GetMoneyProfitAsync(request.RequestParams);
            var newUser = _mapper.Map<User>(userProfit);

            var isUserDuplicated = await _queryRepository.CheckDuplicatesEntriesAsync(newUser);

            if (isUserDuplicated)
            {
                //Lanzar excepción de duplicados.
            }

            var result = await Task.Run(() => { return _commandRepository.AddAsync(newUser); });
            
            return _mapper.Map<UserDto>(result);
        }
    }
}
