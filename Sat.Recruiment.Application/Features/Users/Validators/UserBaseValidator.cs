using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Sat.Recruiment.Application.Features.Users.Dto;


namespace Sat.Recruiment.Application.Features.Users.Validators
{
    internal class UserBaseValidator : AbstractValidator<UserDto>
    {
        public UserBaseValidator() { 
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Address).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Phone).NotNull().NotEmpty();
        }
    }
}
