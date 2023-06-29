using FarmaciaGaluma.Utilidades.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Aplicacion.UseCases;

namespace FarmaciaGaluma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletaController: ControllerBase
    {
        private readonly IBoletaUseCase _boletaUseCase;

        public BoletaController(IBoletaUseCase boletaUseCase)
        {
            _boletaUseCase = boletaUseCase;
        }
                
        
        #region LISTAR MUCHOS REGISTROS
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> UltimoNumero()
        {
            var paqueteDatos = await _boletaUseCase.EjecutarObtenerUltimoNumeroDoc();

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
