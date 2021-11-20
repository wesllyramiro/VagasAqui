using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VA.Domain;
using VA.Infrastructure.Data;

namespace VA.Application.UseCase.CriarCidade
{
    public class CriarCidadeHandler : IRequestHandler<CriarCidadeCommand, int>
    {
        private readonly IApplicationContext _context;

        public CriarCidadeHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CriarCidadeCommand request, CancellationToken cancellationToken)
        {
            var cidade = new Cidade()
            {
                Nome = request.Nome,
                EstadoId = request.IdEstado
            };

            await _context.Cidade.AddAsync(cidade, cancellationToken)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return cidade.Id;
        }
    }
}
