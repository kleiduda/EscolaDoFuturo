using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entity
{
    public class Endereco : Notifiable
    {
        public Endereco()
        {
            
        }
        public string Pais { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public Endereco(string pais, string uf, string cidade, string cep, string bairro, string rua, string numero, string complemento)
        {
            Pais = pais;
            Uf = uf;
            Cidade = cidade;
            Cep = cep;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
        }

        public void Validate(){
            AddNotifications(
                new Contract()
                .Requires()
                .HasMaxLen(Uf, 2, "Uf", "Uf não pode conter mais de 2 caracteres")
            );
        }
    }
}