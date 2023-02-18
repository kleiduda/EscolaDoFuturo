using Domain.ViewModels;

namespace Domain.Arguments.Responses.Aluno
{
    public class AlunoResponse
    {
        public AlunoViewModel Aluno { get; set; }

        public AlunoResponse(AlunoViewModel aluno)
        {
            Aluno = aluno;
        }
    }
}

