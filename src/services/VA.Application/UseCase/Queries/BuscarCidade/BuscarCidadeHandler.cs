using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VA.Domain;
using VA.Infrastructure.Data;

namespace VA.Application.UseCase.Queries.BuscarCidade
{
    public class BuscarCidadeHandler : IRequestHandler<BuscarCidadeQuery, Cidade>
    {
        private readonly IApplicationContext _context;

        public BuscarCidadeHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Cidade> Handle(BuscarCidadeQuery request, CancellationToken cancellationToken)
        {
            var cidade = await _context.Cidade.FirstOrDefaultAsync(cidade => cidade.EstadoId == request.IdEstado
                                                                && cidade.Id == request.IdCidade,
                                                  cancellationToken).ConfigureAwait(false);

            return cidade;
        }
    }
}
