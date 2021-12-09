using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Models
{
    public class Pagamento
    {
        [Key]
        public int Id_Pagamento { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public Cartao Cartao { get; set; }
    }
}
