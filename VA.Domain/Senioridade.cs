namespace VA.Domain
{
    public class Senioridade : Entity
    {
        public string Nome { get; set; }
        public Vaga Vaga { get; set; }
    }
}
