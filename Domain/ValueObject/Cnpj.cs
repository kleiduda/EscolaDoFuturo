using System.Text.RegularExpressions;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.ValueObject
{
    public class Cnpj : Notifiable
    {
        public string Documento { get; set; }
        public Cnpj(string documento)
        {
            Documento = documento;
            if (!ValidaCNPJ(documento))
            {
                AddNotification("CNPJ", "CNPJ inválido");
            }
        }

        private static bool ValidaCNPJ(string cnpj)
        {
            // Verifica se o CNPJ tem o formato correto
            Regex regex = new Regex(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$");
            if (!regex.IsMatch(cnpj))
            {
                return false;
            }

            // Remove a formatação do CNPJ
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

            // Calcula os dígitos verificadores
            int[] digitos = new int[14];
            for (int i = 0; i < 14; i++)
            {
                digitos[i] = int.Parse(cnpj[i].ToString());
            }

            int soma = digitos[0] * 5 + digitos[1] * 4 + digitos[2] * 3 + digitos[3] * 2 + digitos[4] * 9 + digitos[5] * 8 + digitos[6] * 7 + digitos[7] * 6 + digitos[8] * 5 + digitos[9] * 4 + digitos[10] * 3 + digitos[11] * 2;
            int resto = soma % 11;
            int dv1 = resto < 2 ? 0 : 11 - resto;

            soma = digitos[0] * 6 + digitos[1] * 5 + digitos[2] * 4 + digitos[3] * 3 + digitos[4] * 2 + digitos[5] * 9 + digitos[6] * 8 + digitos[7] * 7 + digitos[8] * 6 + digitos[9] * 5 + digitos[10] * 4 + digitos[11] * 3 + digitos[12] * 2;
            resto = soma % 11;
            int dv2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores estão corretos
            return digitos[12] == dv1 && digitos[13] == dv2;
        }

    }
}