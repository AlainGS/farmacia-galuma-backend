using FarmaciaGaluma.Utilidades.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Aplicacion.UseCases;

namespace FarmaciaGaluma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCase _usuarioUseCase;

        public UsuarioController(IUsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }

        [HttpGet]
        [Route("IniciarSesion")]
        public async Task<ActionResult> IniciarSesion(string correo, string clave)
        {
            var paqueteDatos = await _usuarioUseCase.EjecutarValidarCredenciales(correo, clave);

            if (paqueteDatos.estadoData != -1)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));

        }


        #region LISTAR MUCHOS REGISTROS
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Listado()
        {
            var paqueteDatos = await _usuarioUseCase.EjecutarObtenerTodo();

            if (paqueteDatos.estadoData != -1)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));
        }
        #endregion


        #region INSERTAR, ACTUALIZAR y ELIMINAR 1 REGISTRO 
        [HttpPost]
        public Task<ActionResult> Post(BEUsuario entity)
        {
            return guardarCambios(1, entity); //accion 1 = insertar
        }

        [HttpPut("{accion}")]
        public Task<ActionResult> Put(int accion, BEUsuario entity)
        {
            return guardarCambios(accion, entity); //accion 2 = actualizar; accion 3 = eliminar
        }

        private async Task<ActionResult> guardarCambios(int accion, BEUsuario entity)
        {
            var paqueteDatos = await _usuarioUseCase.EjecutarCreaEditaElimina(entity, accion);

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
