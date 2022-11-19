using ControleVeterinario.Api.Controllers.MontadorMensagens;
using ControleVeterinario.Aplicacao.Alimentacoes;
using ControleVeterinario.Aplicacao.Animais;
using ControleVeterinario.Aplicacao.RFIDs;
using ControleVeterinario.Dominio.Alimentacoes;
using ControleVeterinario.Dominio.ControleVeterinarios;
using ControleVeterinario.Dominio.RFIDs;
using ControleVeterinario.Dominio.TipoAnimais;
using ControleVeterinario.Dominio.TipoAnimais.Racas;
using ControleVeterinario.Dominio.Vacinacoes;
using ControleVeterinario.Repositorio.Contexto;
using ControleVeterinario.Repositorio.Repositorios.Alimentacoes;
using ControleVeterinario.Repositorio.Repositorios.ControleVeterinarios;
using ControleVeterinario.Repositorio.Repositorios.RFIDs;
using ControleVeterinario.Repositorio.Repositorios.TipoAnimais;
using ControleVeterinario.Repositorio.Repositorios.TipoAnimais.Racas;
using ControleVeterinario.Repositorio.Repositorios.Vacinacoes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextoBanco>(options => options.UseSqlServer("Data Source=tcp:estudo-jhonnatan-azure.database.windows.net,1433;Initial Catalog=estudos;User Id=jrserafina@estudo-jhonnatan-azure;Password=Jhogame2002"));
builder.Services.AddScoped<IAplicRFID, AplicRFID>();
builder.Services.AddScoped<IAplicAnimal, AplicAnimal>();
builder.Services.AddScoped<IAplicAlimentacao, AplicAlimentacao>();
builder.Services.AddScoped<IRepRFID, RepRFID>();
builder.Services.AddScoped<IRepRaca, RepRaca>();
builder.Services.AddScoped<IMontarMSG, MontarMSG>();
builder.Services.AddScoped<IRepTipoAnimal, RepTipoAnimal>();
builder.Services.AddScoped<IRepAlimentacao, RepAlimentacao>();
builder.Services.AddScoped<IRepVacinacao, RepVacinacao>();
builder.Services.AddScoped<IRepCadastroAnimal, RepCadastroAnimal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
