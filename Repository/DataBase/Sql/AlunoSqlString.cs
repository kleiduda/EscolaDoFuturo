namespace Repository.DataBase.Sql
{
	public static class AlunoSqlString
	{
		public const string CadastroNovoALuno = @"INSERT INTO TB_ALUNO (nome, sobrenome, documento, data_nascimento, cd_turma, cd_periodo, cd_endereco) 
												  VALUES (@nome, @sobrenome, @documento, @dataNascimento, @turma, @periodo, @cd_endereco)";

		public const string ObterAlunoPeloCodigo = @"SELECT 
												         aluno.nome
												         ,aluno.sobrenome
												         FROM TB_ALUNO aluno
												     WHERE
												         aluno.cd_aluno = @CD_ALUNO";

		public const string ListarAlunos = @"SELECT  aluno.[cd_aluno] as CdAluno
											        ,aluno.[nome]
											        ,aluno.[sobrenome]
											        ,aluno.[documento]
											        ,aluno.[data_nascimento] as DataNascimento
											        ,turma.descricao as Turma
											        ,periodo.descricao as Periodo
											    FROM [KSF].[dbo].[TB_ALUNO] aluno
											    INNER JOIN TB_TURMAS turma ON aluno.cd_turma = turma.cd_turma
											    INNER JOIN TB_PERIODOS periodo ON aluno.cd_periodo = periodo.cd_periodo
											 ORDER BY [cd_aluno]
											 OFFSET (@NUMERO_PAGINA -1) * @ITENS_POR_PAGINA ROWS
											 FETCH NEXT @ITENS_POR_PAGINA ROWS ONLY";
	
		public const string ExcluirAluno = @"DELETE FROM TB_ALUNO WHERE CD_ALUNO = @CD_ALUNO";
		public const string ValidarRegistroNaBase = @"SELECT 1 FROM TB_ALUNO WHERE documento = @documento";
	}
}

