global using Microsoft.EntityFrameworkCore;
using COLORADO.Data.Controllers;
using COLORADO.Data.DAL;
using COLORADO.Services;
using COLORADO.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IUserInterface, UserService>();
builder.Services.AddScoped<IOrderInterface, OrderService>();
builder.Services.AddScoped<IDessertInterface, DessertService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
                .AllowAnyOrigin() // Specify the allowed origin (frontend)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
