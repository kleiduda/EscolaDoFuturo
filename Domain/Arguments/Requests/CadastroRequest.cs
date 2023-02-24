using Domain.Entity;

namespace Domain.Arguments.Requests
{
    public class CadastroRequest
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string  Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Turma { get; set; }
        public int Periodo { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Pais { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int CdPessoa { get; set; }
        
    }
}