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
        public async Task<IServiceResult> CadastrarNovoResponsavel([FromBody] CadastroResponsavelRequest request)
        {
            return await _responsavelService.CadastroResponsavel(request);
        }


    }
}