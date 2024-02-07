using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public partial class FarmasupplyContext : DbContext
    {
        public FarmasupplyContext()
        {
        }

        public FarmasupplyContext(DbContextOptions<FarmasupplyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        public virtual DbSet<Tienda> Tiendas { get; set; }

        public virtual DbSet<Pedido> Pedidos { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Name=PostgresConnection");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
    }
}
