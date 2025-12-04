
using Api.Data;
using Api.GenericRepositories.Interfaces;
using Api.GenericRepositories.Repositories;
using Api.Mappings;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//  Connessione al DB
var strConnect = builder.Configuration.GetConnectionString("strCon") ??
    throw new Exception("Attenzione! Verifica la connessione stringa 🧐");

builder.Services.AddDbContext<ScuolaDbContext>(options =>
    options.UseSqlServer(strConnect));

#region  Registrazione Repository e Servizi
// Repository generico (interfaccia → implementazione)
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GRepository<>));

// Se i servizi usano direttamente GRepository<T>
builder.Services.AddScoped(typeof(GRepository<>));

// Servizi applicativi
builder.Services.AddScoped<AulaService>();
builder.Services.AddScoped<StudenteService>();
builder.Services.AddScoped<CorsoService>();
builder.Services.AddScoped<DocenteService>();
builder.Services.AddScoped<LezioneService>();
builder.Services.AddScoped<PresenzaService>();
builder.Services.AddScoped<ValutazioneService>();
builder.Services.AddScoped<IscrizioneService>();
builder.Services.AddScoped<ClasseService>();
builder.Services.AddScoped<VotoService>();
#endregion

// AutoMapper 
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configurazione del CORS per permettere richieste da qualsiasi origine (utile per sviluppo front-end separato)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//   Logging con Serilog
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

//  Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll"); // Abilita il CORS con la policy "AllowAll"
app.UseAuthorization();
app.MapControllers();
app.Run();
