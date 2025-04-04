using APIOne.src.Contratos.IRepository;
using APIOne.src.Contratos.IServices;
using APIOne.src.Repository;
using APIOne.src.Services;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///Conexão co  o banco de dados
builder.Services.AddScoped<IDbConnection>(x => new NpgsqlConnection("Host=localhost;Database=APIDb;Username=postgres;Password=Thienick14"));

// injeção de dependencia
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUsersServices, UserService>();

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
