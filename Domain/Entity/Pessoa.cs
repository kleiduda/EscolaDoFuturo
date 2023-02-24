using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entity
{
    public abstract class Pessoa
    {
        public Pessoa()
        {
            
        }
        protected Pessoa(string nome, string sobreNome, Documento cpf, string rg, ETipoPessoa tipo, string email, 
        string telefone, string celular, DateTime dataNascimento)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Cpf = cpf;
            Rg = rg;
            Tipo = tipo;
            Email = email;
            Telefone = telefone;
            Celular = celular;
            DataNascimento = dataNascimento;
        }
        protected Pessoa(string nome, string sobreNome, Documento cpf, string rg, DateTime dataNascimento)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
        }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public Documento Cpf { get; set; }
        public string Rg { get; set; }
        public ETipoPessoa Tipo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}