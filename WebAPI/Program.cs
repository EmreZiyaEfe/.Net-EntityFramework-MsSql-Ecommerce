using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//IProductService istenen bir yer varsa ona ProductManager ver (IoC)
//Biri constructorda IProductService isterse ona arka planda ProductManager ver demek (referans)
//Data içermeyecek
//ProductManagerda IProductDala baðlý
//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Autofac kullanýmý
builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory()).
    ConfigureContainer<ContainerBuilder>(builder => 
    { 
        builder.RegisterModule(new AutofacBusinessModule()); 
    });

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
