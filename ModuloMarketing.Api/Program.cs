using Microsoft.EntityFrameworkCore;
using ModuloMarketing.Api.Repository;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//insira a string connection
builder.Services.AddDbContext<DbContexto>(options =>
	options.UseNpgsql("Host=150.136.54.24:5435;Username=postgres;Password=admin;Database=marketingdb")
);

builder.Services.AddControllers();

//Adicionar inje��es dos repositories
builder.Services.AddScoped<ICampanhaRepository, CampanhaRepository>();
builder.Services.AddScoped<IHistoricoCampanhasRepository, HistoricoCampanhasRepository>();
builder.Services.AddScoped<IDataComemorativaRepository, DataComemorativaRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
