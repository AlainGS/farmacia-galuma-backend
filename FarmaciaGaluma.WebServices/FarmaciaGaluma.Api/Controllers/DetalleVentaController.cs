using FarmaciaGaluma.Utilidades.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Aplicacion.UseCases;
using FarmaciaGaluma.Aplicacion.UseCases.Implementacion;

namespace FarmaciaGaluma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IDetalleVentaUseCase _detalleVentaUseCase;

        public DetalleVentaController(IDetalleVentaUseCase detalleVentaUseCase)
        {
            _detalleVentaUseCase = detalleVentaUseCase;
        }
            
        #region
        [HttpGet]
        [Route("BuscarDetalleVenta")]
        public async Task<ActionResult> BuscarDetalleVenta(int id)
        {
            var paqueteDatos = await _detalleVentaUseCase.EjecutarBusquedaDV(id);

            if (paqueteDatos.estadoData != -1)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));

        }
        #endregion

    }
}
