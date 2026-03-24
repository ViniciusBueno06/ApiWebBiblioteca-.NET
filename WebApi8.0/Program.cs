using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using WebApi8._0.Data;
using WebApi8._0.Services.Autor;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
//.env
Env.Load("../.env");



var builder = WebApplication.CreateBuilder(args);

//             Var. de Ambiente
builder.Configuration.AddEnvironmentVariables();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//             INFRA
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connection))
{
    throw new InvalidOperationException("Connection string não configurada. Verifique o arquivo .env");
}
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connection);
   
});


//             SERVICES
builder.Services.AddScoped<IAutorInterface, AutorService>();







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
