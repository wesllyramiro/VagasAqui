using VA.API.Data.Entidades;
using VA.API.Data.Repositories.Empresa;
using VA.API.Models;

namespace VA.API.Services
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresaRepository _repository;
        public EmpresaServices(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        public void CriarEmpresa(EmpresaModel model) 
        {
            var entidade = new Empresa(model.Nome, model.IdCidade, model.IdUsuario);

            _repository.CriarEmpresa(entidade);
        }
    }
}
