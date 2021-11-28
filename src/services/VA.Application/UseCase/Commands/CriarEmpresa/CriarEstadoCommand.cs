using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VA.Domain;
using VA.Infrastructure.Data;

namespace VA.Application.UseCase.Commands.CriarEmpresa
{
    public class CriarEstadoCommand : IRequest<int>
    {
        public CriarEstadoCommand(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }

        public class CriarEstadoCommandValidator : AbstractValidator<CriarEstadoCommand>
        {
            public CriarEstadoCommandValidator()
            {
                RuleFor(c => c.Nome).NotEmpty();
            }
        }

        public class CriarEstadoCommandHandlers : IRequestHandler<CriarEstadoCommand, int>
        {
            private readonly IApplicationContext _context;
            public CriarEstadoCommandHandlers(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CriarEstadoCommand request, CancellationToken cancellationToken)
            {
                var estado = new Estado()
                {
                    Nome = request.Nome
                };

                await _context.Estado.AddAsync(estado, cancellationToken)
                    .ConfigureAwait(false);

                await _context.SaveChangesAsync().ConfigureAwait(false);

                return estado.Id;
            }
        }
    }
}
