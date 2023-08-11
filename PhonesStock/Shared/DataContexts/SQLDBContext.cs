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
                optionsBuilder.UseSqlServer("Data Source=RAUL\\SQLEXPRESS;Initial Catalog=Phones;Integrated Security=True;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Puedes configurar aquí las relaciones y propiedades de la tabla si es necesario
        }
    }
}
