using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Aplication.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TRespose> : IPipelineBehavior<TRequest, TRespose> where TRequest : IRequest<TRespose>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TRespose> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRespose> next)
        {
            var contex = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(v => v.Validate(contex))
                .SelectMany(result => result.Errors)
                .Where(failures => failures != null).ToList();
            
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
