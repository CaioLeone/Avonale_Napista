using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Napista.Models;

namespace Napista.Data
{
    public class ApiDbConteudo : DbContext
    {
        public ApiDbConteudo(DbContextOptions<ApiDbConteudo>options) : base(options)
        {

        }

        public DbSet<Produtos> Produtos { get; set; }
    }
}
