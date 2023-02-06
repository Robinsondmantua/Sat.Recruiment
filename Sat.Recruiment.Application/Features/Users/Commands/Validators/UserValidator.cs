using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Sat.Recruiment.Application.Features.Users.Commands.Request;
using Sat.Recruiment.Application.Features.Users.Validators;

namespace Sat.Recruiment.Application.Features.Users.Commands.Validators
{
    /// <summary>
    /// Class to validate a normal user
    /// </summary>

    internal class UserValidator : AbstractValidator<NewUserRequest>
    {
        public UserValidator()
        {
            RuleFor(v => v.RequestParams).SetValidator(new UserBaseValidator());
        }
    }
}
