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

        public bool Equals(Entity obj)
        {
            return Id.Equals(obj.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return GetType() == obj.GetType() && Equals((Entity)obj);
        }
        public static bool operator ==(Entity left, Entity right)
        {
            return left.Id.Equals(right.Id);
        }
        public static bool operator !=(Entity left, Entity right)
        {
            return !left.Id.Equals(right.Id);
        }
    }
}
