using MediatR;

namespace VA.Application.UseCase.Commands
{

    public class CriarEmpresaCommand : IRequest<int>
    {
        public CriarEmpresaCommand(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
