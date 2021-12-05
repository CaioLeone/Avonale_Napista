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

        public Cartao(string titular, int numero, DateTime data_expedicao, string bandeira, int cvv)
        {
            Titular = titular;
            Numero = numero;
            Data_expedicao = data_expedicao;
            Bandeira = bandeira;
            Cvv = cvv;
        }
    }
}
