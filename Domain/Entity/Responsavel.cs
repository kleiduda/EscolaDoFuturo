using System;
using Domain.ValueObject;

namespace Domain.Entity
{
	public class Responsavel
	{
        public Responsavel(Nome nome, string documento,
            Aluno aluno)
        {
            Nome = nome;
            Documento = documento;
            Aluno = aluno;
        }

        public Nome Nome { get; set; }
		public string Documento { get; set; }
		public Aluno Aluno { get; set; }
	}
}

