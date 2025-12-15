using Microsoft.EntityFrameworkCore;
using TestApi.Services;
using TestApi.Models.Entity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionString = string.Empty;

try
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not found!");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(connectionString)
);


builder.Services.AddScoped<StudentService>();


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
