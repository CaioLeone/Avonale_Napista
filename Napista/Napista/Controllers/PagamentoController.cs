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
    public class PagamentoController : ControllerBase
    {
        //Variavel de Conexão com o banco de dados
        private ApiDbConteudo _dbConteudo;
        public PagamentoController(ApiDbConteudo dbConteudo) 
        {
            _dbConteudo = dbConteudo;
        }

        //Metodo HTTP Post para adição do pagamento
        
        //EndPoint POST api/<PagamentoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pagamento pagamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _dbConteudo.Pagamento.AddAsync(pagamento);
            if (pagamento != null)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
            await _dbConteudo.SaveChangesAsync();
            return Ok("Pagamento Cadastrado.");
        }
    }
}
