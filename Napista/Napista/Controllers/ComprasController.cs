using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Napista.Data;
using Napista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        //Variavel de Conexão com o banco de dados
        private ApiDbConteudo _dbConteudo;

        public ComprasController(ApiDbConteudo dbConteudo) 
        {
            _dbConteudo = dbConteudo;
        }

        //Metodo HTTP Post para adição de Compras, utilizando validação de dados
        // POST api/<ComprasController>
        [HttpPost]
        public IActionResult Post([FromBody] Compras compra)
        {
            
            _dbConteudo.Compras.AddAsync(compra);
            if (compra == null)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
            _dbConteudo.SaveChangesAsync();
            return Ok("Compra Cadastrado.");
        }
    }
}
