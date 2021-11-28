using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using VA.Domain;
using VA.Infrastructure.CrossCutting.Shared;
using VA.Infrastructure.Data;

namespace VA.Application.UseCase.Queries.BuscarCidade
{
    public class BuscarCidadeHandler : IRequestHandler<BuscarCidadeQuery, Output<Cidade>>
    {
        private readonly IApplicationContext _context;

        public BuscarCidadeHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Output<Cidade>> Handle(BuscarCidadeQuery request, CancellationToken cancellationToken)
        {
            var cidade = await _context.Cidade.FirstOrDefaultAsync(cidade => cidade.EstadoId == request.IdEstado
                                                                && cidade.Id == request.IdCidade,
                                                  cancellationToken).ConfigureAwait(false);

            return new Output<Cidade>(cidade);
        }
    }
}
