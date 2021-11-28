using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VA.Domain;
using VA.Infrastructure.CrossCutting.Shared;
using VA.Infrastructure.Data;

namespace VA.Application.UseCase.Commands.CriarEmpresa
{
    public class CriarEmpresaCommandHandlers : IRequestHandler<CriarEmpresaCommand, Output<int>>
    {
        private readonly IApplicationContext _context;
        public CriarEmpresaCommandHandlers(IApplicationContext context)
        {
            _context = context;
        }
        public async Task<Output<int>> Handle(CriarEmpresaCommand request, CancellationToken cancellationToken)
        {
            var empresa = new Empresa()
            {
                Nome = request.Nome
            };

            await _context.Empresa.AddAsync(empresa, cancellationToken)
                .ConfigureAwait(false);

            await _context.SaveChangesAsync().ConfigureAwait(false);

            return new Output<int>(empresa.Id);
        }
    }
}