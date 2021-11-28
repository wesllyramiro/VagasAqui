using MediatR;
using VA.Domain;
using VA.Infrastructure.CrossCutting.Shared;

namespace VA.Application.UseCase.Queries.BuscarCidade
{
    public class BuscarCidadeQuery : IRequest<Output<Cidade>>
    {
        public BuscarCidadeQuery(int idEstado, int idCidade)
        {
            IdEstado = idEstado;
            IdCidade = idCidade;
        }

        public int IdEstado { get; }
        public int IdCidade { get; }
    }
}
