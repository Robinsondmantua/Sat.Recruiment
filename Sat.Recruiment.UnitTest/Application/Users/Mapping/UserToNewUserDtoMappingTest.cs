using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture.AutoMoq;
using AutoFixture;
using AutoMapper;
using Sat.Recruiment.Application.Features.Users.Mapping;
using Xunit;
using Sat.Recruiment.Domain.Models;
using Sat.Recruiment.Application.Features.Users.Dto;
using FluentAssertions;

namespace Sat.Recruiment.UnitTest.Application.Users.Mapping
{
    /// <summary>
	/// Unit test for User mapping class
	/// </summary>
    public class UserToNewUserDtoMappingTest
    {
        private readonly IMapper _mapper;

        public UserToNewUserDtoMappingTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            });

            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void UserEntity_To_NewUserDto()
        {
            //Arrange
            var fixture = new Fixture();
            var user = fixture.Create<User>();

            //Act
            var dto = _mapper.Map<NewUserDto>(user);

            //Assert
            dto.Phone.Should().Be(user.Phone);
            dto.Address.Should().Be(user.Address);
            dto.Email.Should().Be(user.Email);
            dto.Money.Should().Be(user.Money);
            dto.UserType.Should().Be(user.UserType);
        }
    }
}
