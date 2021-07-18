using System;

namespace VA.API.Data.Entidades
{
    public class Empresa
    {
        public Empresa(string nome, int idCidade, int usuario)
        {
            Nome = nome;
            IdCidade = idCidade;
            Usuario = usuario;
            DataCriacao = DateTime.Now;
        }
        protected Empresa() { }

        public string Nome { get; set; }
        public int IdCidade { get; set; }
        public int Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
