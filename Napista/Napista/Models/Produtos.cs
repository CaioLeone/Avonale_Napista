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

        [Required(ErrorMessage = " Nome do produto deve ser preenchido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = " Valor do produto deve ser preenchido")]
        public float Valor_unitario { get; set; }

        [Required(ErrorMessage = " Quantidade do produto deve ser preenchido")]
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
