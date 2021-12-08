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

    }
}
