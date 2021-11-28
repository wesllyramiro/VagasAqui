using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VA.Domain;
using VA.Infrastructure.CrossCutting.Shared;
using VA.Infrastructure.Data;

namespace VA.Application.UseCase.Commands.CriarCidade
{
    public class CriarCidadeHandler : IRequestHandler<CriarCidadeCommand, Output<int>>
    {
        private readonly IApplicationContext _context;

        public CriarCidadeHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Output<int>> Handle(CriarCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidade = new Cidade()
            {
                Nome = request.Nome,
                EstadoId = request.IdEstado
            };

            await _context.Cidade.AddAsync(cidade, cancellationToken)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return  new Output<int>(cidade.Id);
        }
    }
}
