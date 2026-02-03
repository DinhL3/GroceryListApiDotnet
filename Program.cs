using Microsoft.EntityFrameworkCore;
using GroceryListApiDotnet.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (like configuring beans in Spring Boot)
builder.Services.AddControllers();

// Configure database (like application.properties in Spring Boot)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable Swagger for API documentation (optional but helpful)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline (like middleware in Express)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();  // Maps your controller routes

app.Run();