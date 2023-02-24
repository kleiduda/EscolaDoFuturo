using Flunt.Notifications;

namespace Domain.ValueObject
{
    public class Documento : Notifiable
    {
        public string Numero { get; set; }
        public Documento(string numero)
        {
            Numero = numero;
            if (!ValidaDocumento(numero))
            {
                AddNotification("CPF/CNPJ", "CPF ou CNPJ inválido");       
            }
        }
        
        public static bool ValidaDocumento(string cpf)
        {
            // Remove caracteres que não sejam números
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais
            if (cpf.Distinct().Count() == 1)
            {
                return false;
            }

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            }
            int resto = soma % 11;
            int primeiroDigito = (resto < 2) ? 0 : 11 - resto;

            // Verifica se o primeiro dígito está correto
            if (primeiroDigito != int.Parse(cpf[9].ToString()))
            {
                return false;
            }

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            }
            resto = soma % 11;
            int segundoDigito = (resto < 2) ? 0 : 11 - resto;

            // Verifica se o segundo dígito está correto
            if (segundoDigito != int.Parse(cpf[10].ToString()))
            {
                return false;
            }

            // CPF válido
            return true;
        }

    }
}