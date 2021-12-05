using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Models
{
    public class Produtos
    {
        public string Nome { get; set; }
        public float Valor_unitario { get; set; }
        public int qtde_estoque { get; set; }

        public Produtos(string nome, float valor_unitario, int qtde_estoque)
        {
            Nome = nome;
            Valor_unitario = valor_unitario;
            this.qtde_estoque = qtde_estoque;
        }
    }
}
