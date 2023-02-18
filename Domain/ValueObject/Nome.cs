using System;
namespace Domain.ValueObject
{
	public class Nome
	{
        public Nome(string primeiroNome, string sobreNome)
        {
            PrimeiroNome = primeiroNome;
            SobreNome = sobreNome;
        }

        public string PrimeiroNome { get; set; }
		public string SobreNome { get; set; }

        public override string ToString()
        {
            return $"{PrimeiroNome} {SobreNome}";
        }
    }
}

