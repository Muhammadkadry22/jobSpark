using jobSpark.core;
using jobSpark.Service;
using jobSpark.Infrastructure;
using jobSpark.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using jobSpark.core.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddInfrastructureDependencies()
                 .AddServiceDependencies()
                 .AddCoreDependencies()
                 .AddServiceRegisteration(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
    );

/*builder.Services.AddInfrustructureDependencies()
                .AddCoreDependencies()
                .AddServiceDependencies();*/

/*Serilog Configration*/

var configSerilog = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configSerilog)
                .CreateLogger();

builder.Services.AddSerilog();


builder.Services.AddCors(corsOptions => {
    corsOptions.AddPolicy("MyPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");

app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
