namespace VA.Domain
{
    public class Usuario : Entity
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public Perfil Perfil { get; set; }
    }
}
