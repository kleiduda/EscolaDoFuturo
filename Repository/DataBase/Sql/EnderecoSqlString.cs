namespace Repository.DataBase.Sql
{
    public static class EnderecoSqlString
    {
        public const string CadastroEndereco = @"INSERT INTO TB_ENDERECO
												 (pais, uf, cidade, cep, bairro, rua, numero, complemento) 
												 VALUES (@pais, @uf, @cidade, @cep, @bairro, @rua, @numero, @complemento); 
												 SELECT CAST(SCOPE_IDENTITY() as int)";

        
    }
}

