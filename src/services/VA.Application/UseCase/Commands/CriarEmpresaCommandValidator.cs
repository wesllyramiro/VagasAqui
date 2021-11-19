using FluentValidation;

namespace VA.Application.UseCase.Commands
{
    public class CriarEmpresaCommandValidator : AbstractValidator<CriarEmpresaCommand>
    {
        public CriarEmpresaCommandValidator()
        {
            RuleFor(c => c.Nome).NotEmpty();
        }
    }
}
