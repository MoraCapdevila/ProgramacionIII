using Microsoft.EntityFrameworkCore;
using ProgramacionIII.Data.Context;
using ProgramacionIII.Services.Implementations;
using ProgramacionIII.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Conexion con la db
builder.Services.AddDbContext<EcommerceContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["DB:ConnectionString"]));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inyecciones
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdminService, AdminService>();

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
