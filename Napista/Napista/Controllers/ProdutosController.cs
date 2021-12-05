using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Napista.Models;

namespace Napista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private static List<Produtos> produtos = new List<Produtos>()
        {
            new Produtos(){Nome = "Machado Duplo", Valor_unitario = 50 ,Qtde_estoque = 5},
            new Produtos(){Nome = "Clava", Valor_unitario = 75, Qtde_estoque = 3 }
        };

        [HttpGet]
        public IEnumerable<Produtos> Get()
        {
            return produtos;
        }

        [HttpPost]
        public void Post([FromBody] Produtos produto)
        {
            produtos.Add(produto);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Produtos produto)
        {
            produtos[id] = produto;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            produtos.RemoveAt(id);
        }
    }
}
