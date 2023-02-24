using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entity
{
    public class Aluno : Pessoa
    {
        public Aluno() { }
        public Aluno(string nome, string sobreNome, Documento cpf, string rg, ETipoPessoa tipo, string email, string telefone, 
        string celular, DateTime dataNascimento, int turma, int periodo)
        : base(nome, sobreNome, cpf, rg, tipo, email, telefone, celular, dataNascimento)
        {
            Turma = turma;
            Periodo = periodo;
        }

        public int CdAluno { get; set; }
        public int Turma { get; set; }
        public string DescricaoTurma { get; set; }
        public int Periodo { get; set; }
    }
}

