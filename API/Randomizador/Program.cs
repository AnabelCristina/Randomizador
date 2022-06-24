using Microsoft.EntityFrameworkCore;
using Randomizador.DAL;
using Randomizador.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<PersonagensService>();
builder.Services.AddTransient<LugaresService>();
builder.Services.AddTransient<AcoesService>();
builder.Services.AddTransient<ObjetosService>();

builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        });
    }
);


string connectionString = "Server=.\\SQLExpress;Database=Randomizador;Trusted_Connection=True;";
// se não estiver usando o SQLExpress tente
// Server=localhost;Database=Randomizador;Trusted_Connection=True;
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));



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

app.UseCors();

app.Run();
