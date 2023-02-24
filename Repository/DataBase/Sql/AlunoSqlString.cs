namespace Repository.DataBase.Sql
{
	public static class AlunoSqlString
	{
		public const string CadastroNovoALuno = @"INSERT INTO TB_ALUNO 
													(cd_turma, cd_periodo, cd_pessoa) 
												  VALUES 
												  	(@turma, @periodo, @cd_pessoa)";

		public const string ObterAlunoPeloCodigo = @"SELECT
														aluno.cd_aluno
														,pessoa.nome
														,pessoa.sobrenome
														,pessoa.cpf
														,pessoa.rg
														,turma.descricao as DescricaoTurma
														,aluno.cd_periodo as Periodo
														FROM TB_PESSOA pessoa
														INNER JOIN TB_ALUNO aluno ON pessoa.cd_pessoa = aluno.cd_pessoa
														INNER JOIN TB_TURMAS turma ON aluno.cd_turma = turma.cd_turma
														INNER JOIN TB_PERIODOS periodo ON aluno.cd_periodo = periodo.cd_periodo
													WHERE
												         pessoa.cd_pessoa = @cd_pessoa";

		public const string ListarAlunos = @"SELECT
												aluno.cd_aluno
												,pessoa.nome
												,pessoa.sobrenome
												,pessoa.cpf
												,pessoa.rg
												,turma.descricao as DescricaoTurma
												,aluno.cd_periodo as Periodo
												FROM TB_PESSOA pessoa
												INNER JOIN TB_ALUNO aluno ON pessoa.cd_pessoa = aluno.cd_pessoa
												INNER JOIN TB_TURMAS turma ON aluno.cd_turma = turma.cd_turma
												INNER JOIN TB_PERIODOS periodo ON aluno.cd_periodo = periodo.cd_periodo
											 ORDER BY aluno.cd_aluno
											 OFFSET (@NUMERO_PAGINA -1) * @ITENS_POR_PAGINA ROWS
											 FETCH NEXT @ITENS_POR_PAGINA ROWS ONLY";
	
		public const string ExcluirAluno = @"DELETE FROM TB_PESSOA WHERE CD_PESSOA = @CD_PESSOA";
		public const string ValidarRegistroNaBase = @"SELECT 1 FROM TB_PESSOA WHERE cpf = @cpf";
	}
}

