using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Sat.Recruiment.Application.Features.Users.Request;

namespace Sat.Recruiment.Application.Features.Users.Validators
{
    /// <summary>
    /// Class to validate a normal user
    /// </summary>

    internal class NormalUserValidator : AbstractValidator<NormalUserRequest>
    {
        public NormalUserValidator()
        {
            RuleFor(v => v.RequestParams).SetValidator(new UserBaseValidator());
        }
    }
}
