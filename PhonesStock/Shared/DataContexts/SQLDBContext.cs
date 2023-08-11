using Microsoft.EntityFrameworkCore;
using PhonesStock.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PhonesStock.Shared.DataContexts
{
    public class SQLDBContext: DbContext
    {
        public SQLDBContext()
        {
        }
        public SQLDBContext(DbContextOptions<SQLDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=bonsectanew.database.windows.net;Initial Catalog=Phones;User ID=lemustiano;Password=LemusH69#;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Puedes configurar aquí las relaciones y propiedades de la tabla si es necesario
        }
    }
}
