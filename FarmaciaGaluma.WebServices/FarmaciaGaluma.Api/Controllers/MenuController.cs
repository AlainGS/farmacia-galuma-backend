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
    public class MenuController : ControllerBase
    {
        private readonly IMenuUseCase _menuUseCase;

        public MenuController(IMenuUseCase menuUseCase)
        {
            _menuUseCase = menuUseCase;
        }
            
        #region
        [HttpGet]
        [Route("ListaMenu")]
        public async Task<ActionResult> ListadoMenu(int idUsuario)
        {
            var paqueteDatos = await _menuUseCase.EjecutarListadoMenu(idUsuario);

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
