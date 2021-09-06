namespace VA.Domain
{
    public class Habilidade : Entity
    {
        public string Nome { get; set; }

        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
