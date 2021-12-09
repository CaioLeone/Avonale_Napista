using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Models
{
    public class Cartao
    {
        [Required]
        public string Titular { get; set; }
        [Key]
        public double Numero { get; set; }
        [Required]
        public DateTime Data_expedicao { get; set; }
        [Required]
        public string Bandeira { get; set; }
        [Required]
        public int Cvv { get; set; }
    }
}
