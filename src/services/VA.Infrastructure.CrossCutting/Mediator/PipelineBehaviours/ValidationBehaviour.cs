using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VA.Infrastructure.CrossCutting.Shared;

namespace VA.Infrastructure.CrossCutting.PipelineBehaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : Output, new()
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationResults = ProcessValidations(request);

            var result = CreateResult(validationResults);

            return await VerifyNextStepAsync(request, result, next).ConfigureAwait(false);

        }
        private IEnumerable<ValidationResult> ProcessValidations(TRequest request)
        {
            foreach (var validator in _validators)
            {
                yield return validator.Validate(request);
            }
        }
        public static TResponse CreateResult(IEnumerable<ValidationResult> validationResult)
        {
            if (typeof(TResponse) == typeof(Output))
            {
                return (TResponse)new Output(validationResult);
            }

            var tOutput = CreateTOutputWithValidatonResult(validationResult);

            return tOutput;
        }
        private static TResponse CreateTOutputWithValidatonResult(IEnumerable<ValidationResult> validationResults)
        {
            var tOutput = new TResponse();
            tOutput.ProcessValidationResults(validationResults.ToArray());

            return tOutput;
        }
        private async Task<TResponse> VerifyNextStepAsync(TRequest request, Output output, RequestHandlerDelegate<TResponse> proceedToCommandHandler)
        {
            if (output.IsValid)
            {
                return await proceedToCommandHandler().ConfigureAwait(false);
            }

            var nextStep = output as TResponse;

            return nextStep;
        }
    }
}
