using Lanche_Bom.Context;
using Lanche_Bom.Models;

namespace Lanche_Bom.Data
{
    public class LanchesContextSeed
    {
        public static void SeedAsync(AppDbContext context)
        {
            var itemPedidos = new List<ItemPedido>
            {
                new ItemPedido
                {
                    Id = 1,
                    Nome = "X Burger",
                    Preco = 5.00M,
                    Categoria = "Lanche"
                },
                 new ItemPedido
                {
                    Id = 2,
                    Nome = "X Salada",
                    Preco = 4.50M,
                    Categoria = "Lanche"
                },
                 new ItemPedido
                {
                    Id = 3,
                    Nome = "X Tudo",
                    Preco = 7.00M,
                    Categoria = "Lanche"
                },
                 new ItemPedido
                {
                    Id = 4,
                    Nome = "Batata Frita",
                    Preco = 2.00M,
                    Categoria = "Adicional"
                },
                 new ItemPedido
                {
                    Id = 5,
                    Nome = "Refrigerante",
                    Preco = 2.50M,
                    Categoria = "Adicional"
                }
            };
            context.ItensPedido.AddRange(itemPedidos);
            context.SaveChanges();
        }
    }
}