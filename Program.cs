using ExperimentNetApi6.Data;
using ExperimentNetApi6.Services;
using Microsoft.EntityFrameworkCore;
using ExperimentNetApi6.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddControllers();

builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    app.UseDeveloperExceptionPage();
} else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Map("/usingMap", builder => {
    builder.Use(async (context, next) =>
    {
        await Console.Out.WriteLineAsync("UsingMap: before next");
        await next.Invoke();
        await Console.Out.WriteLineAsync("UsingMap: after next");
    });
    builder.Run(async context => {
        await Console.Out.WriteLineAsync("UsingMap from Run method.");
        await context.Response.WriteAsync("UsingMap Page");
    });
});

app.Use(async (context, next) =>
{
    await Console.Out.WriteLineAsync("Logic before calling next");
    await next.Invoke();
    await Console.Out.WriteLineAsync("1st Custom middleware, after next");
});
app.Run(async context =>
{
    await Console.Out.WriteLineAsync("2nd Custom middleware");
    await context.Response.WriteAsync("Hello from middleware component.");
});

app.Run();