using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface IRolUseCase
    {
        Task<RARdata<List<BERol>>> EjecutarObtenerTodo();
    }
}
