using MediatR;
using VA.Domain;

namespace VA.Application.UseCase.Queries.BuscarCidade
{
    public class BuscarCidadeQuery : IRequest<Cidade>
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
