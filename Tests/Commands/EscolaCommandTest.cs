using Domain.Commands.EscolaCommands;
using Domain.Entity;

namespace Tests.Commands
{
    [TestClass]
    public class EscolaCommandTest
    {
        [TestMethod]
        public void DeveValidarQuandoCommandForInvalido()
        {
            var Cnpj = "";
            var RazaoSocial = "INSTITUICAO PAULISTA ADVENTISTA DE EDUC E ASS SOCIAL";
            var NomeFantasia = "COLEGIO ADVENTISTA DE INDAIATUBA";
            var Pais = "Brasil";
            var Estado = "SP";
            var Cidade = "São Paulo";
            var Cep = "133395545";
            var Bairro = "Jardim Santiago";
            var Rua = "Rua Pedro Virillo";
            var Numero = "320";
            var Complemento = "";
            var Telefone = "1920850185";
            var Telefone2 = "1920850185";
            var Email = "contatocolegioadventistaindaiatuba.gov.br";
            Escola escola = new Escola(Cnpj, RazaoSocial, NomeFantasia, Pais, Estado, Cidade, Cep, Bairro, Rua, Numero, Complemento, Telefone, Telefone2, Email);
            var command = new EscolaCommand(escola);
            

            Assert.AreEqual(true, command.Valid);
        }
    }
}