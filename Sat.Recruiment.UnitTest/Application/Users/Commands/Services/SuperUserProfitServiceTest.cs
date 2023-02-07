using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Sat.Recruiment.Application.Features.Users.Commands.Services.Profit;
using Xunit;

namespace Sat.Recruiment.UnitTest.Application.Users.Commands.Services
{
    public class SuperUserProfitServiceTest
    {

        private readonly SuperUserProfitService _sut;

        public SuperUserProfitServiceTest()
        {
            _sut = new SuperUserProfitService();
        }

        [Fact]
        internal async Task GetMoneyProfitAsync_ShouldReturn303M_WhenMoneyIs101()
        {
            //Assert 
            decimal money = 101.0M;

            //Act
            var result = await _sut.GetMoneyProfitAsync(money);

            //Assert
            result.Should().Be(121.20M);

        }
    }
}