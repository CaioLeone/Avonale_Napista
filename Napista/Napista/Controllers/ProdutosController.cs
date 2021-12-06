using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Produtos> Get()
        {
            return _dbConteudo.Produtos;
        }

        // GET api/<ProdutosController>/5
        [HttpGet("{id}")]
        public Produtos Get(int id)
        {
            var produto = _dbConteudo.Produtos.Find(id);
            return produto;
        }

        // POST api/<ProdutosController>
        [HttpPost]
        public void Post([FromBody] Produtos produto)
        {
            _dbConteudo.Produtos.Add(produto);
            _dbConteudo.SaveChanges();
        }

        // PUT api/<ProdutosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Produtos produto)
        {
            var prod = _dbConteudo.Produtos.Find(id);
            prod.Nome = produto.Nome;
            prod.Valor_unitario = produto.Valor_unitario;
            prod.Qtde_estoque = produto.Qtde_estoque;
            _dbConteudo.SaveChanges();
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var produto = _dbConteudo.Produtos.Find(id);
            _dbConteudo.Produtos.Remove(produto);
            _dbConteudo.SaveChanges();
        }
    }
}
