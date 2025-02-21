using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.UseCases.Products;
using Microsoft.AspNetCore.Builder;
using Application.UseCases.Suppliers;
using Application.Mappings;
using AutoMapper;
using Application.UseCases.Categories;

var builder = WebApplication.CreateBuilder(args);

// Configure connection string
builder.Services.AddDbContext<InventoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//Auto Mapper configuration
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register Use Cases
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

builder.Services.AddScoped<GetAllCategory>();
builder.Services.AddScoped<GetCategoryById>();
builder.Services.AddScoped<AddCategory>();
builder.Services.AddScoped<UpdateCategory>();
builder.Services.AddScoped<DeleteCategory>();





// Add CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // URL de tu aplicación Angular
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS before authorization and controllers
app.UseCors("AllowAngularClient");

app.UseAuthorization();

app.MapControllers();

app.Run();
