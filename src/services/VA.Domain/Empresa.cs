using System.Collections.Generic;

namespace VA.Domain
{
    public class Empresa : Entity
    {
        public string Nome { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        public Pagina Pagina { get; set; }
        public ICollection<Vaga> Vagas { get; set; }
    }
}
