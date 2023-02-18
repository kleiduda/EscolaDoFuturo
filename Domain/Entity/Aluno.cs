using System;
using Domain.Enums;
using Domain.ValueObject;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entity
{
    public class Aluno : Notifiable
    {
        public Aluno()
        {
            
        }
        public Aluno(int cdAluno, string nome, string sobrenome,
            DateTime datanascimento, string turma, string periodo, string documento, Endereco endereco)
        {
            AddNotifications(new Contract().HasMinLen(nome, 3, "Nome", "teste"));
            CdAluno = cdAluno;
            Nome = nome;
            SobreNome = sobrenome;
            Datanascimento = datanascimento;
            Turma = turma;
            Periodo = periodo;
            Documento = documento;
            Endereco = endereco;
        }

        public int CdAluno { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Documento { get; set; }
        public DateTime Datanascimento { get; set; }
        public string Turma { get; set; }
        public string Periodo { get; set; }
        public Endereco Endereco { get; set; }

    }
}

