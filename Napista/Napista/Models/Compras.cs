using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Models
{
    public class Compras
    {
        [Key]
        public int Produto_Id { get; set; }
        [Required]
        public int Qtde_comprada { get; set; }
        [Required]
        public Cartao Cartao { get; set; }
        
    }
}
