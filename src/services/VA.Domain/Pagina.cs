namespace VA.Domain
{
    public class Pagina : Entity
    {
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }
    }
}
