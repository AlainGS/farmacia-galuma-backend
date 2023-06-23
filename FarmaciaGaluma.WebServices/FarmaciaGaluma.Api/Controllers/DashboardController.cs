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
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardUseCase _dashboardUseCase;

        public DashboardController(IDashboardUseCase dashboardUseCase)
        {
            _dashboardUseCase = dashboardUseCase;
        }
            
        #region
        [HttpGet]
        [Route("Resumen")]
        public async Task<ActionResult> Resumen()
        {
            var paqueteDatos = await _dashboardUseCase.EjecutarResumen();

            if (paqueteDatos.estadoData != -1)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));

        }

        [HttpGet]
        [Route("GraficoBarras")]
        public async Task<ActionResult> GraficoBarras()
        {
            var paqueteDatos = await _dashboardUseCase.EjecutarGraficoBarras();

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
