using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController, Route("usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;

    public UsuarioController(IUsuarioService service)
    {
        _service = service;
    }
    [HttpPost("cadastro")]
    public async Task<IServiceResult> CadastrarNovoUsuario([FromBody] CadastroUsuarioRequest request)
    {
        return await _service.CadastroUsuario(request);
    }

    // [HttpGet("buscar")]
    // public async Task<IServiceResult> ObterAlunoPeloCodigo(int codigoALuno)
    // {
    //     return await _alunoService.ObterAlunoPeloCodigo(codigoALuno);
    // }
}
