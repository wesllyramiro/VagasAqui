using MediatR;

namespace VA.Application.UseCase.Commands
{
    public class CriarCidadeCommand : IRequest<int>
    {
        public int Nome { get; set; }
        public int EstadoId { get; set; }
    }
}
