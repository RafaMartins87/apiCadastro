using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Api.Common;
using Api.Repository;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsAllowAll")]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepository _cadastroRepository;

        public CadastroController(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }

        /// <summary>
        /// Insere um objeto para cadastro.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPost]
        public IActionResult CadastroAdd(CadastroModel dados)
        {
            try
            {
                return Ok(_cadastroRepository.CadastroAdd(dados));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroAdd", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroAdd", ex.Message));
            }
        }


    }
}
