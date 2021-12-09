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
        [Required]
        public string Nome { get; set; }
        [Required]
        public float Valor_unitario { get; set; }
        [Required]
        public int Qtde_estoque { get; set; }
        [Required]
        public float Valor_venda { get; set; }
        public DateTime? Data_venda { get; set; }

    }
}
