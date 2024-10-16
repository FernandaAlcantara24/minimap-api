using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinimalApi.Infraestrutura.Db;
using MinimalApi.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddDbContext<DbContexto>(Options => {
    Options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect( builder.Configuration.GetConnectionString("mysql"))
    );
});


app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (MinimalApi.DTOs.LoginDTO loginDTO) => {
    if(loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
       return Results.Ok("Login com sucesso!");
    else 
        return Results.Unauthorized();
});


app.Run();

