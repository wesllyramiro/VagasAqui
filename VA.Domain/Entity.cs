using System;

namespace VA.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public int? UsuarioCriacao { get; set; }
        public DateTime? CadastradoEm { get; set; }
        public int? UsuarioAlteracao { get; set; }
        public DateTime? AlteradoEm { get; set; }
    }
}
