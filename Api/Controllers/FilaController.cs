using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController, Route("fila")]
public class FilaController : ControllerBase
{
    private readonly IFilaService _service;

    public FilaController(IFilaService service)
    {
        _service = service;
    }
    [HttpPost("entrada")]
    public async Task<IServiceResult> CadastrarNovoAluno([FromBody] CadastroEscolaRequest request)
    {
        return null;
    }

    // [HttpGet("buscar")]
    // public async Task<IServiceResult> ObterAlunoPeloCodigo(int codigoALuno)
    // {
    //     return await _alunoService.ObterAlunoPeloCodigo(codigoALuno);
    // }
}
