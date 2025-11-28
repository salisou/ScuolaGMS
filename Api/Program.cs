using Api.Data;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var strConnect = builder.Configuration.GetConnectionString("strCon") ??
    throw new Exception("Attenzione! Verifica la connessione stringa 🧐");

builder.Services.AddDbContext<ScuolaDbContext>(options => options.UseSqlServer(strConnect));

#region Generic Repository and Services
//builder.Services.AddScoped(typeof(IGenericRepository<>, typeof(Repository<>));
builder.Services.AddScoped<AulaService>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Log del api salvato in .log-.txt
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

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
