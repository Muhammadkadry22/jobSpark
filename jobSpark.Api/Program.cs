using jobSpark.core;
using jobSpark.Service;
using jobSpark.Infrastructure;
using jobSpark.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
    );
builder.Services.AddInfrustructureDependencies()
                .AddCoreDependencies()
                .AddServiceDependencies();



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
