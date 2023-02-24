using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entity
{
    public class Responsavel : Pessoa
    {
        public Responsavel()
        {
            
        }
        public Responsavel(string nome, string sobreNome,Documento cpf, string rg, ETipoPessoa tipo, string email, 
        string telefone, string celular, DateTime dataNascimento)
        :base(nome, sobreNome, cpf, rg, tipo, email, telefone, celular, dataNascimento)
        {
        }
        public int CdResponsavel { get; set; }

    }
}

