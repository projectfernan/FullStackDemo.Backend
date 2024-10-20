using FullStackDemo.WebApi.Mappings;
using FullStackDemo.WebApi.Configurations;
using FullStackDemo.Infrastructure.Persistence.Data.Dapper;

var builder = WebApplication.CreateBuilder(args);

// Configure log4net
builder.ConfigureLogging();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Configure database
//DbContext
builder.Services.ConfigureDatabase(builder.Configuration);
//Dapper
builder.Services.AddScoped<IGundamDb, GundamDb>();

// Add JWT authentication
builder.Services.AddJwtAuthentication(builder.Configuration);

// Register repositories
builder.Services.AddRepositories();

// Register application services
builder.Services.AddApplicationServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();