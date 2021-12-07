using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Napista.Data;
using Napista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Napista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ApiDbConteudo _dbConteudo;

        public ProdutosController(ApiDbConteudo dbConteudo)
        {
            _dbConteudo = dbConteudo;
        }

        // GET: api/<ProdutosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbConteudo.Produtos.ToListAsync());
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var produto = await _dbConteudo.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
            else
            {
                return Ok(produto);
            }
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produtos produto)
        {
            await _dbConteudo.Produtos.AddAsync(produto);
            if (produto != null ) 
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
            await _dbConteudo.SaveChangesAsync();
            return Ok("Produto Cadastrado.");
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Produtos produto)
        {
            var prod = await _dbConteudo.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Valores Informados não são validos.");
            }
            else
            {
                prod.Nome = produto.Nome;
                prod.Valor_unitario = produto.Valor_unitario;
                prod.Qtde_estoque = produto.Qtde_estoque;
                await _dbConteudo.SaveChangesAsync();
                return Ok("Produto Alterado Com Sucesso.");
            }
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await _dbConteudo.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
            else
            {
                _dbConteudo.Produtos.Remove(produto);
                await _dbConteudo.SaveChangesAsync();
                return Ok("Protudo excluido Com Sucesso");
            }
        }
    }
}
