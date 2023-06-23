using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface IVentaUseCase
    {
        Task<RARdata<List<BEVenta>>> EjecutarObtenerTodo();
        Task<RARdata<List<BEVentaDetallado>>> EjecutarObtenerTodoDetallado();
        Task<RARdata<BEVenta>> EjecutarRegistrar(BEVenta venta, int accion);
        Task<RARdata<List<BEVenta>>> EjecutarHistorial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<RARdata<BEReporte>> EjecutarReporte(string fechaInicio, string fechaFin);

    }
}
