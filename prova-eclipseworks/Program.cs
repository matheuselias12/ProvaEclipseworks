using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using prova_eclipseworks.Data;
using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository;
using prova_eclipseworks.Repository.Interface;
using prova_eclipseworks.Service;
using prova_eclipseworks.Service.Interface;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ProvaEclipseworksDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddScoped<IProjetoRepository, ProjetoRepository>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IProjetoService, ProjetoService>();

builder.Services.AddAutoMapper(typeof(ConfigurationMapping));


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Gerente", policy => policy.RequireRole("GerenteProjeto"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DatabaseManagementService.MigrationInitialisation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
