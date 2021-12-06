using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Models
{
    public class Produtos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Valor_unitario { get; set; }
        public int Qtde_estoque { get; set; }

        public Produtos()
        {
        }

        public Produtos(int id, string nome, float valor_unitario, int qtde_estoque)
        {
            Id = id;
            Nome = nome;
            Valor_unitario = valor_unitario;
            Qtde_estoque = qtde_estoque;
        }
    }
}
