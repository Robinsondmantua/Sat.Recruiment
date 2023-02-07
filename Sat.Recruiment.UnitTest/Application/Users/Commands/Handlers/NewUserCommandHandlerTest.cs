using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.AutoMoq;
using AutoFixture;
using AutoMapper;
using Moq;
using Sat.Recruiment.Application.Common.Abstractions;
using Sat.Recruiment.Application.Features.Users.Abstractions;
using Sat.Recruiment.Application.Features.Users.Commands.Handlers;
using Sat.Recruiment.Application.Features.Users.Mapping;
using Sat.Recruiment.Domain.Enums;
using Xunit;
using Sat.Recruiment.Application.Features.Users.Commands.Request;
using System.Collections;
using FluentAssertions;
using Sat.Recruiment.Application.Common.Exceptions;
using Sat.Recruiment.Domain.Models;

namespace Sat.Recruiment.UnitTest.Application.Users.Commands.Handlers
{
    /// <summary>
    /// Unit test for NewUserCommandHandler class
    /// </summary>
    public class NewUserCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<Func<UserType, IUserProfit>> _userType = new Mock<Func<UserType, IUserProfit>>();
        private readonly Mock<IUserProfit> _userProfit = new Mock<IUserProfit>();
        private readonly Mock<IQueryRepository<Domain.Models.User>> _userQueryRepository = new Mock<IQueryRepository<Domain.Models.User>>();
        private readonly Mock<ICommandRepository<Domain.Models.User>> _userCommandRepository = new Mock<ICommandRepository<Domain.Models.User>>();
        private readonly NewUserCommandHandler _sut;
        private readonly Fixture _fixture;
        public NewUserCommandHandlerTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            });

            _mapper = mockMapper.CreateMapper();

            _sut = new NewUserCommandHandler(_userType.Object,
                _userCommandRepository.Object,
                _userQueryRepository.Object,
                _mapper);

            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization());
        }

        [Fact]
        public async Task HandleMethod_WhenUserIsDuplicated_ShouldReturnDuplicateDataException()
        {
            //Arrange
            var commandRequest = _fixture.Create<NewUserRequest>();
            _userType.Setup(r => r(It.IsAny<UserType>())).Returns(_userProfit.Object);
            _userProfit.Setup(r=>r.GetMoneyProfitAsync(It.IsAny<decimal>())).ReturnsAsync(0.8M);
            _userQueryRepository.Setup(r => r.CheckDuplicatesEntriesAsync(It.IsAny<User>())).ReturnsAsync(true);
            //Act
            Func<Task> act = async () => await _sut.Handle(commandRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<DuplicateDataException>();
        }

        [Fact]
        public async Task HandleMethod_WhenUserIsNotDuplicated_ShouldReturnValidUserDto()
        {
            //Arrange
            var commandRequest = _fixture.Create<NewUserRequest>();
            var newUser = User.Create(commandRequest.RequestParams.Name,
                commandRequest.RequestParams.Email, commandRequest.RequestParams.Address,
                commandRequest.RequestParams.Phone, commandRequest.RequestParams.UserType,
                0.8M
                );

            _userType.Setup(r => r(It.IsAny<UserType>())).Returns(_userProfit.Object);
            _userProfit.Setup(r => r.GetMoneyProfitAsync(It.IsAny<decimal>())).ReturnsAsync(0.8M);
            _userQueryRepository.Setup(r => r.CheckDuplicatesEntriesAsync(It.IsAny<User>())).ReturnsAsync(false);
            _userCommandRepository.Setup(r => r.AddAsync(It.IsAny<User>())).ReturnsAsync(newUser);
            
            //Act
            var result = await _sut.Handle(commandRequest, CancellationToken.None);

            //Assert
            result.Email.Should().Be(commandRequest.RequestParams.Email);
            result.Address.Should().Be(commandRequest.RequestParams.Address);
            result.Money.Should().Be(0.8M);
            result.Name.Should().Be(commandRequest.RequestParams.Name);
            result.Phone.Should().Be(commandRequest.RequestParams.Phone);
            result.UserType.Should().Be(commandRequest.RequestParams.UserType);
        }
    }
}
