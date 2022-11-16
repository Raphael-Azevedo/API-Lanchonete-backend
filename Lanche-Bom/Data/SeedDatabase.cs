using Lanche_Bom.Context;

namespace Lanche_Bom.Data
{
    public class SeedDatabase
    {
        public static void SeedDb(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AppDbContext>();
            if (context.Database.EnsureCreated())
            {
                LanchesContextSeed.SeedAsync(context);
            }
        }
    }
}