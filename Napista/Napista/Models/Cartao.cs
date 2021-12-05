using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Models
{
    public class Cartao
    {
        public string Titular { get; set; }
        public int Numero { get; set; }
        public DateTime Data_expedicao { get; set; }
        public string Bandeira { get; set; }
        public int Cvv { get; set; }
    }
}
