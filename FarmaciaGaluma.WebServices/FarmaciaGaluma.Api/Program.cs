using FarmaciaGaluma.Aplicacion.UseCases;
using FarmaciaGaluma.Aplicacion.UseCases.Implementacion;
using FarmaciaGaluma.Infraestructura.Repositorios;
using FarmaciaGaluma.Infraestructura.Repositorios.Implementacion;
using FarmaciaGaluma.Utilidades.Utils;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Conexion GLOBAL a la BASE de DATOS de FARMACIAGALUMA
SqlConexionFarmacia.CadenaSQL = builder.Configuration.GetConnectionString("FarmaciaDB");

builder.Services.AddControllers();

// CasosDeUso y Repositorios de USUARIO
builder.Services.AddScoped<IUsuarioUseCase, UsuarioUseCase>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// CasosDeUso y Repositorios de ROL
builder.Services.AddScoped<IRolUseCase, RolUseCase>();
builder.Services.AddScoped<IRolRepository, RolRepository>();

// CasosDeUso y Repositorios de CATEGORIA
builder.Services.AddScoped<ICategoriaUseCase,CategoriaUseCase>();
builder.Services.AddScoped<ICategoriaRepository,CategoriaRepository>();

// CasosDeUso y Repositorios de PRODUCTO
builder.Services.AddScoped<IProductoUseCase, ProductoUseCase>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

// CasosDeUso y Repositorios de VENTA
builder.Services.AddScoped<IVentaUseCase, VentaUseCase>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();

// CasosDeUso y Repositorios de NUMERODOCUMENTO
builder.Services.AddScoped<IBoletaUseCase, BoletaUseCase>();
builder.Services.AddScoped<IBoletaRepository, BoletaRepository>();

// CasosDeUso y Repositorios de DETALLEVENTA
builder.Services.AddScoped<IDetalleVentaUseCase, DetalleVentaUseCase>();
builder.Services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();

// CasosDeUso y Repositorios de DASHBOARD
builder.Services.AddScoped<IDashboardUseCase, DashboardUseCase>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();

// CasosDeUso y Repositorios de MENU
builder.Services.AddScoped<IMenuUseCase, MenuUseCase>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin() //cualquier origen
        .AllowAnyHeader()
        .AllowAnyMethod(); // get, post, put, delete
    });
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Version = "v1", 
        Title = "Farmacia Galuma API", 
        Description = "API para consumir los metodos del sistema Farmacia Galuma",
        TermsOfService = new Uri("https://www.cibertec.edu.pe")
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Farmacia Galuma API v1");

    });
}

app.UseCors("NuevaPolitica");
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
