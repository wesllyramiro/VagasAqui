using FluentValidation;

namespace VA.Application.UseCase.Commands.CriarCidade
{
    public class CriarCidadeValidator : AbstractValidator<CriarCidadeCommand>
    {
        public CriarCidadeValidator()
        {
            RuleFor(c => c.Nome).NotEmpty();
            RuleFor(c => c.IdEstado).GreaterThan(0);
        }
    }
}
