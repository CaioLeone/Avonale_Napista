using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Napista.Models
{
    public class Compras
    {
        public int Produto_id { get; set; }
        public int Qtde_comprada { get; set; }
        public Cartao Cartao { get; set; }

        public Compras(int produto_id, int qtde_comprada)
        {
            Produto_id = produto_id;
            Qtde_comprada = qtde_comprada;
        }
    }
}
