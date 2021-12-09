using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ProdutosController : ControllerBase
    {
        //Variavel de Conexão com o banco de dados
        private ApiDbConteudo _dbConteudo;

        public ProdutosController(ApiDbConteudo dbConteudo) {
            _dbConteudo = dbConteudo;
        }
        //Metodo Get para Listar Todos os Produtos pelo nome, valor unitario e quantidade de estoque
        // GET: api/<ProdutosController>
        [HttpGet]
        public async Task<IActionResult> GetProduto()
        {
            var produto = await (from produtos in _dbConteudo.Produtos
                          select new
                          {
                              Nome = produtos.Nome,
                              Valor_unitario = produtos.Valor_unitario,
                              Qtde_estoque = produtos.Qtde_estoque
                          }).ToListAsync();
            return Ok(produto);
        }
       
        //Metodo Get para Pesquisar produtos de forma detalhada, mostrando todas variaveis da Classe
        [HttpGet("[action]")]
        public IActionResult ProdutosDetalhes(int id)
        {
            var produtosDetalhes = _dbConteudo.Produtos.FindAsync(id);
            if (produtosDetalhes != null)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
            else {
                return Ok(produtosDetalhes); 
            }
        }
        
        //Metodo Post para adição de produto, utilizando validação
        // POST api/<ProdutosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produtos produto)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            await _dbConteudo.Produtos.AddAsync(produto);
            if (produto != null)
            {
                return NotFound("Ocorreu um erro desconhecido");
            }
            await _dbConteudo.SaveChangesAsync();
            return Ok("Produto Cadastrado.");
        }

        //Metodo Delete para remoção de um elemento pelo ID informado, Caso o ID nao existe, uma
        //mensagem de erro irá aparecer
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
                return Ok("Produto excluido Com Sucesso");
            }
        }
    }
}
