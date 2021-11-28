using MediatR;
using VA.Infrastructure.CrossCutting.Shared;

namespace VA.Application.UseCase.Commands.CriarEmpresa
{

    public class CriarEmpresaCommand : IRequest<Output<int>>
    {
        public CriarEmpresaCommand(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
