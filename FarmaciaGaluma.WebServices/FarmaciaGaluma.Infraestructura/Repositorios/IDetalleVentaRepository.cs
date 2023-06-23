using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Infraestructura.Repositorios
{
    public interface IDetalleVentaRepository
    {
        Task<RARdata<List<BEDetalleVenta>>> BusquedaDV(int idVenta);
    }
}
