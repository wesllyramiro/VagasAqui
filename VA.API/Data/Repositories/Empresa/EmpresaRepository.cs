using Dapper;
using VA.API.Data.Fabrica;

namespace VA.API.Data.Repositories.Empresa
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IConnectionFactory _factory;

        public EmpresaRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public void CriarEmpresa(Entidades.Empresa empresa) 
        {
            using (var con = _factory.CreateSqlConnectionOpened())
            {
                var insert = EmpresaScripts.CriarEmpresa();

                con.Execute(insert, empresa);
            }
        }
    }
}
