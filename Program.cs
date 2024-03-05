using ExperimentNetApi6.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.Configure<ExternalMicroServicesConfig>(builder.Configuration.GetSection(nameof(ExternalMicroServicesConfig)));

builder.Services.AddDbContext<ExperimentNetApi6Context>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("ExperminetNet6Connection"));
});


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

