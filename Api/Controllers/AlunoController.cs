using Api.Common.Swagger;
using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers;

[SwaggerGroup("Api de Alunos")]
[ApiController, Route("aluno")]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }
    [HttpPost("cadastro")]
    public async Task<IServiceResult> CadastrarNovoAluno([FromBody] CadastroAlunoRequest request)
    {
         return await _alunoService.CadastroAluno(request);
    }

    [HttpGet("buscar")]
    public async Task<IServiceResult> ObterAlunoPeloCodigo(int codigoALuno)
    {
        return await _alunoService.ObterAlunoPeloCodigo(codigoALuno);
    }

    [HttpPost("listar")]
    public async Task<IServiceResult> ListarAlunos([FromBody] FilterRequest request)
    {
        return await _alunoService.ListarAlunos(request);
    }

    [HttpDelete("excluir")]
    public async Task<IServiceResult> ExcluirAluno(int codigoAluno)
    {
        return await _alunoService.ExcluirAluno(codigoAluno);
    }
}
