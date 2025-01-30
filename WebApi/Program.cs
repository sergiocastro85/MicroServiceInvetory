using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.UseCases.Products;
using Microsoft.AspNetCore.Builder;
using Application.UseCases.Suppliers;


var builder = WebApplication.CreateBuilder(args);

//configure connetion string

builder.Services.AddDbContext<InventoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Register Repositories

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();

//Register Use Cases
builder.Services.AddScoped<GetAllProducts>();
builder.Services.AddScoped<GetProductById>();
builder.Services.AddScoped<AddProduct>();
builder.Services.AddScoped<UpdateProduct>();
builder.Services.AddScoped<DeleteProduct>();

builder.Services.AddScoped<GetAllSuppliers>();
builder.Services.AddScoped<GetSupplierById>();
builder.Services.AddScoped<AddSupplier>();
builder.Services.AddScoped<UpdateSupplier>();
builder.Services.AddScoped<DeleteSupplier>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
