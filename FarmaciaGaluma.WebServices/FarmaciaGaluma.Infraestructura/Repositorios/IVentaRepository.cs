using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Infraestructura.Repositorios
{
    public interface IVentaRepository
    {
        Task<RARdata<List<BEVenta>>> ObtenerTodo();
        Task<RARdata<List<BEVentaDetallado>>> ObtenerTodoDetallado();
        Task<RARdata<BEVenta>> Registrar(BEVenta venta, int accion);
        Task<RARdata<List<BEVenta>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<RARdata<BEReporte>> Reporte(string fechaInicio, string fechaFin);
    }
}
