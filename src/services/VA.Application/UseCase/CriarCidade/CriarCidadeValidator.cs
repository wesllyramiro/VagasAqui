using FluentValidation;

namespace VA.Application.UseCase.CriarCidade
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
