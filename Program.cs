using despesas_pessoais.Data;
using despesas_pessoais.Interfaces;
using despesas_pessoais.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDBContext>(options =>
{
    if (builder.Configuration.GetConnectionString("banco") == "sql")
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString(builder.Configuration.GetConnectionString("banco") ?? "sql"));
    }
    else
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(builder.Configuration.GetConnectionString("banco") ?? "postgres"));
    }
});

builder.Services.AddScoped<IDespesasRepository,DespesasRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // /swagger/index.html

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
