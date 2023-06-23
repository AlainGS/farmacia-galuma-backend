using FarmaciaGaluma.Datos.Entidades;

namespace FarmaciaGaluma.Datos.Repositorio
{
    public interface IEmpleadoRepositorio
    {
        Task<List<Empleado>> ObtenerEmpleado();
    }
}
