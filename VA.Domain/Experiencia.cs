using System;

namespace VA.Domain
{
    public class Experiencia : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
