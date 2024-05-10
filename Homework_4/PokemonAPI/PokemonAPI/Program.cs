using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PokemonAPI.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// builder.Services.AddStackExchangeRedisCache(options => {
//     options.Configuration = "localhost:6379";
//     options.InstanceName = "local";
// });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultValue")));

builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllerRoute(
    name: "PokemonRoutes",
    pattern: "{controller=Pokemon}/{action=Index}/{id?}");

app.UseHttpsRedirection();

app.Run();