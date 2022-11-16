using Lanche_Bom.Models;
using Microsoft.EntityFrameworkCore;

namespace Lanche_Bom.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ItemPedido> ItensPedido { get; set; } = null!;
        public DbSet<Pedido> Pedidos { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasMany(a => a.ItensPedido);

            base.OnModelCreating(modelBuilder);
        }
    }
}