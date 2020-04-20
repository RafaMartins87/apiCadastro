using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Common
{
    public class UtilController : ControllerBase
    {
        public ActionResult verificaStatus(string retorno)
        {
            if (retorno == "OK")
            {
                return Ok(retorno);
            }
            else
            {
                return BadRequest("Erro : " + retorno);
            }
        }

    }
}
