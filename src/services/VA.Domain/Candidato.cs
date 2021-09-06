namespace VA.Domain
{
    public class Candidato : Entity
    {
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }
    }
}
