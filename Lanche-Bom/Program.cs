using Lanche_Bom.Context;
using Lanche_Bom.Data;
using Lanche_Bom.Repository;
using Lanche_Bom.Repository.Interfaces;
using Lanche_Bom.Services;
using Lanche_Bom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlite("Data Source = ./Data/Lanche.db"));

builder.Services.AddScoped<IUnityOfWork, UnityOfWork>();
builder.Services.AddScoped<IItemPedidoServices, ItemPedidoServices>();
builder.Services.AddScoped<IPedidoServices, PedidoServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

SeedDatabase.SeedDb(app);

app.MapControllers();

app.Run();
