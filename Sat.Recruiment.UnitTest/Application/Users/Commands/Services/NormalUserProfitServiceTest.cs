using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sat.Recruiment.Application.Features.Users.Commands.Handlers;
using Sat.Recruiment.Application.Features.Users.Commands.Services.Profit;
using Xunit;

namespace Sat.Recruiment.UnitTest.Application.Users.Commands.Services
{
    /// <summary>
    /// Unit test for NormalUserProfitService class
    /// </summary>

    public class NormalUserProfitServiceTest
    {
        private readonly NormalUserProfitService _sut;

        public NormalUserProfitServiceTest()
        {
            _sut = new NormalUserProfitService();
        }

        [Fact]
        internal async Task GetMoneyProfitAsync_ShouldReturn113_120M_WhenMoneyIs101()
        {
            //Assert 
            decimal money = 101.0M;

            //Act
            var result = await _sut.GetMoneyProfitAsync(money);

            //Assert
            result.Should().Be(113.120M);
        }

        [Fact]
        internal async Task GetMoneyProfitAsync_ShouldReturn162M_WhenMoneyIs90()
        {
            //Assert 
            decimal money = 90.0M;

            //Act
            var result = await _sut.GetMoneyProfitAsync(money);

            //Assert
            result.Should().Be(162M);
        }

        [Fact]
        internal async Task GetMoneyProfitAsync_ShouldReturnMoney_WhenMoneyIsLessThan10()
        {
            //Assert 
            decimal money = 9.0M;

            //Act
            var result = await _sut.GetMoneyProfitAsync(money);

            //Assert
            result.Should().Be(9.0M);
        }

    }
}
