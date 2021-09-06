using System.Collections.Generic;

namespace VA.Domain
{
    public class Perfil : Entity
    {
        public string Nome { get; set; }
        public string Curriculo { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }

        public ICollection<Experiencia> Experiencias { get; set; }
        public ICollection<Candidato> Candidaturas { get; set; }
        public ICollection<Habilidade> Habilidades { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Pagina> Paginas { get; set; }
    }
}
