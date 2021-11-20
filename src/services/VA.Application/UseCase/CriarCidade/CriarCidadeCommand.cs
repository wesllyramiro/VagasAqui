using MediatR;

namespace VA.Application.UseCase.CriarCidade
{
    public class CriarCidadeCommand : IRequest<int>
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
