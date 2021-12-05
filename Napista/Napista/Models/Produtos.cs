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
        public int Qtde_estoque { get; set; }

        public Produtos()
        {
        }

        public Produtos(string nome, float valor_unitario, int qtde_estoque)
        {
            Nome = nome;
            Valor_unitario = valor_unitario;
            Qtde_estoque = qtde_estoque;
        }
    }
}
