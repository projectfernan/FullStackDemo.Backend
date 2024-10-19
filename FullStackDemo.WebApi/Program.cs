using FullStackDemo.ApplicationService.Queries.Interfaces.IMobileSuits;
using FullStackDemo.ApplicationService.Queries.QueryHandlers.MobileSuits;
using FullStackDemo.Domain.RepositoriesInterface;
using FullStackDemo.Infrastructure.Persistence.Data.Dapper;
using FullStackDemo.Infrastructure.Persistence.Repositories.MobileSuits;
using FullStackDemo.WebApi.Mappings;
using log4net.Config;
using log4net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configure log4net
var loggerRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(loggerRepository, new FileInfo("log4net.config"));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dapper
builder.Services.AddScoped<IGundamDb, GundamDb>();

//Repositories
builder.Services.AddScoped<IMobileSuitRepository, MobileSuitsQueryRepository>();

//Services
builder.Services.AddScoped<IMobileSuitQueryHandler, MobileSuitQueryHandler>();

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