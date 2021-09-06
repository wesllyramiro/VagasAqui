using System.Collections.Generic;

namespace VA.Domain
{
    public class Vaga : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int SenioridadeId { get; set; }
        public Senioridade Senioridade { get; set; }

        public ICollection<Candidato> Candidato { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
