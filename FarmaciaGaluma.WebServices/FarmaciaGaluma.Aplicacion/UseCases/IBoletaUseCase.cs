using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;
using System.Data;

namespace FarmaciaGaluma.Aplicacion.UseCases
{
    public interface IBoletaUseCase
    {
        Task<RARdata<BEBoleta>> EjecutarObtenerUltimoNumeroDoc();
    }
}
