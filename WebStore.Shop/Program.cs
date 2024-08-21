using WebStore.Shop.Business;
using WebStore.Shop.Business.Interfaces;
using WebStore.Shop.Data.Interfaces;
using WebStore.Shop.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//https://kenslearningcurve.com/tutorials/use-a-3-tier-architecture-with-c/
builder.Services
    .AddDbContext<DataContext>(options =>
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]),
        ServiceLifetime.Scoped);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IProductService, ProductService>();

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

