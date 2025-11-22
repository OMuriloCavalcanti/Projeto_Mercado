using APIMercado.Data;
using APIMercado.Services;
using APIMercado.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("local")));


builder.Services.AddScoped(typeof(IGenerics<>), typeof(ServiceGeneric<>));
builder.Services.AddScoped<IProduto, ServiceProduto>();


builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();