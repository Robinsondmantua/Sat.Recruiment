using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Sat.Recruiment.Application.Features.Users.Request;

namespace Sat.Recruiment.Application.Features.Users.Validators
{
    internal class SuperUserValidator : AbstractValidator<SuperUserRequest>
    {
        public SuperUserValidator()
        {
            RuleFor(v => v.RequestParams).SetValidator(new UserBaseValidator());
        }
    }
}
