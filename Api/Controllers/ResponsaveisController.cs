using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Arguments.Requests;
using Domain.Arguments.Responses;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class ResponsaveisController : Controller
    {
        private readonly IResponsavelService _responsavelService;
        public ResponsaveisController(IResponsavelService service)
        {
            _responsavelService = service;
        }

        [HttpPost("cadastro")]
        public async Task<IServiceResult> CadastrarNovoResponsavel([FromBody] CadastroRequest request)
        {
            return await _responsavelService.CadastroResponsavel(request);
        }
        [HttpPost("listar")]
        public async Task<IServiceResult> ListarAlunos([FromBody] FilterRequest request)
        {
            return await _responsavelService.ListarResponsaveis(request);
        }
        [HttpGet("buscar")]
        public async Task<IServiceResult> ObterResponsavelPeloCodigo(int codigo)
        {
            return await _responsavelService.ObterResponsavelPeloCodigo(codigo);
        }
        [HttpDelete("excluir")]
        public async Task<IServiceResult> ExcluirResponsavel(int codigo)
        {
            return await _responsavelService.ExcluirResponsavel(codigo);
        }

    }
}