using System.Collections.Generic;

namespace VA.Domain
{
    public class Cidade : Entity
    {
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Empresa> Empresas { get; set; }
        public ICollection<Perfil> Perfils { get; set; }
    }
}
