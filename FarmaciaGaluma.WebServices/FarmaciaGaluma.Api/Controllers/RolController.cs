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
    public class RolController : ControllerBase
    {
        private readonly IRolUseCase _rolUseCase;

        public RolController(IRolUseCase rolUseCase)
        {
            _rolUseCase = rolUseCase;
        }
                
        
        #region LISTAR MUCHOS REGISTROS
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Listado()
        {
            var paqueteDatos = await _rolUseCase.EjecutarObtenerTodo();

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
