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
    [Route("api")]
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
        [HttpPost("Cria")]
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

        /// <summary>
        /// Get todos.
        /// </summary>
        /// <returns>Exibe todos os cadastros</returns>
        /// <response code="200">Ok</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpGet("GetAll")]
        public IActionResult CadastroGet()
        {
            try
            {
                return Ok(_cadastroRepository.CadastroGet());
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroGet", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroGet", ex.Message));
            }
        }

        /// <summary>
        /// Atualiza dados.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpPost("Update")]
        public IActionResult CadastroUpd(CadastroModel dados)
        {
            try
            {
                return Ok(_cadastroRepository.CadastroUpd(dados));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroUpd", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroUpd", ex.Message));
            }
        }

        /// <summary>
        /// Deletar dados.
        /// </summary>
        /// <returns>Insere Cadastro</returns>
        /// <response code="200">Cadastro inserido</response>
        /// <response code="511">Usuário não autenticado</response>
        /// <response code="500">Erro no método</response>
        [HttpDelete("Deleta")]
        public IActionResult CadastroDel(int id)
        {
            try
            {
                return Ok(_cadastroRepository.CadastroDel(id));
            }
            catch (Exception ex)
            {
                new MyLog().GerarLog("CadastroDel", "Erro ao buscar todas as avarias", ex);
                return BadRequest(new Error(HttpStatusCode.InternalServerError, "CadastroDel", ex.Message));
            }
        }

    }
}
