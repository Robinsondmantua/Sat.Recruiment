using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Sat.Recruiment.Application.Common.Behaviors
{
    /// <summary>
    /// Mediatr pipeline to validate all incoming parameters using fluentvalidation. When the validation fails
    /// an exception is throwing
    /// </summary>
    /// <typeparam name="TRequest"></typeparam> Request
    /// <typeparam name="TResponse"></typeparam> Response
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
