using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController, Route("escola")]
public class EscolaController : ControllerBase
{
    private readonly IEscolaService _escolaService;

    public EscolaController(IEscolaService escolaService)
    {
        _escolaService = escolaService;
    }
    [HttpPost("cadastro")]
    public async Task<IServiceResult> CadastrarNovoAluno([FromBody] CadastroEscolaRequest request)
    {
        return await _escolaService.CadastroEscola(request);
    }

    // [HttpGet("buscar")]
    // public async Task<IServiceResult> ObterAlunoPeloCodigo(int codigoALuno)
    // {
    //     return await _alunoService.ObterAlunoPeloCodigo(codigoALuno);
    // }
}
