namespace Domain.Entity
{
    public class Escola
    {
        public Escola(string cnpj, string razaoSocial, string nomeFantasia, string pais, string estado, string cidade, 
        string cep, string bairro, string rua, string numero, string complemento, string telefone, string telefone2, string email)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Pais = pais;
            Estado = estado;
            Cidade = cidade;
            Cep = cep;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Telefone = telefone;
            Telefone2 = telefone2;
            Email = email;
        }

        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{string.Join(this.Cnpj, " - ", this.NomeFantasia)}";
        }
    }

}