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
        public int Id_Compra { get; set; }
        public int Qtde_comprada { get; set; }
        public Cartao Cartao { get; set; }
        public ICollection<Produtos> Produto { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }

    }
}
