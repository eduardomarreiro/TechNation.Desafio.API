using Microsoft.EntityFrameworkCore;
using TechNation.Desafio.Application.Interfaces;
using TechNation.Desafio.Application.Mappings;
using TechNation.Desafio.Application.Services;
using TechNation.Desafio.Domain.Entities;
using TechNation.Desafio.Domain.Interfaces.Repositories;
using TechNation.Desafio.Domain.Interfaces.Services;
using TechNation.Desafio.Domain.Services;
using TechNation.Desafio.Infra.Context;
using TechNation.Desafio.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqlContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("TechNationContextConnection")));

#region IOC
//AutoMapper
builder.Services.AddAutoMapper(typeof(ProfileBase));

// Application Services
builder.Services.AddScoped<INotaFiscalApplicationService, NotaFiscalApplicationService>();
builder.Services.AddScoped<IStatusNotaFiscalApplicationService, StatusNotaFiscalApplicationService>();

// Domain Services
builder.Services.AddScoped<INotaFiscalService, NotaFiscalService>();
builder.Services.AddScoped<IStatusNotaFiscalService, StatusNotaFiscalService>();

// Repositories
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<INotaFiscalRepository, NotaFiscalrepository>();
builder.Services.AddScoped<IStatusNotaFiscalRepository, StatusNotaFiscalRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Database Migrations

using var provider = app.Services.CreateScope();
var context = provider.ServiceProvider.GetRequiredService<SqlContext>();
context.Database.Migrate();

#endregion

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
