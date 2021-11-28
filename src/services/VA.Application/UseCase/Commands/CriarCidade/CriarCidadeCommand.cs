using MediatR;
using VA.Infrastructure.CrossCutting.Shared;

namespace VA.Application.UseCase.Commands.CriarCidade
{
    public class CriarCidadeCommand : IRequest<Output<int>>
    {
        public CriarCidadeCommand(string nome, int idEstado)
        {
            Nome = nome;
            IdEstado = idEstado;
        }

        public string Nome { get; set; }
        public int IdEstado { get; }
    }
}
