using Microsoft.EntityFrameworkCore;
using ModuloMarketing.Api.Repository;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//insira a string connection
builder.Services.AddDbContext<DbContexto>(options =>
	options.UseNpgsql(builder.Configuration["ConnectionString"])
);

builder.Services.AddControllers();

//Adicionar inje��es dos repositories
builder.Services.AddScoped<IProdutosEmPromocaoRepository, ProdutosEmPromocaoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
