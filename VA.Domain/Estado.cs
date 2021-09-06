using System.Collections.Generic;

namespace VA.Domain
{
    public class Estado : Entity
    {
        public string Nome { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
    }
}
