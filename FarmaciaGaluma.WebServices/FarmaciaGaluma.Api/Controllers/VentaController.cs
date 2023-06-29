using FarmaciaGaluma.Utilidades.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Aplicacion.UseCases;
using FarmaciaGaluma.Aplicacion.UseCases.Implementacion;
using System;

namespace FarmaciaGaluma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaUseCase _ventaUseCase;

        public VentaController(IVentaUseCase ventaUseCase)
        {
            _ventaUseCase = ventaUseCase;
        }
            

        #region LISTAR MUCHOS REGISTROS
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Listado()
        {
            var paqueteDatos = await _ventaUseCase.EjecutarObtenerTodo();

            if (paqueteDatos.estadoData != -1)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> ListadoDetallado()
        {
            var paqueteDatos = await _ventaUseCase.EjecutarObtenerTodoDetallado();

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
        public Task<ActionResult> Post(BEVenta entity)
        {
            return guardarCambios(1, entity); //accion 1 = insertar
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> PostPorChatBot(BEVentaUnProducto entity)
        {
            var paqueteDatos = await _ventaUseCase.EjecutarVentaPorChatBot(entity);

            if (paqueteDatos.estadoData != -1)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));
        }

        [HttpPut("{accion}")]
        public Task<ActionResult> Put(int accion, BEVenta entity)
        {
            return guardarCambios(accion, entity); //accion 2 = actualizar; accion 3 = eliminar
        }

        private async Task<ActionResult> guardarCambios(int accion, BEVenta entity)
        {
            var paqueteDatos = await _ventaUseCase.EjecutarRegistrar(entity, accion);

            if (paqueteDatos.estadoData != -1)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));
        }
        #endregion

        #region
        [HttpGet]
        [Route("HistorialVentas")]
        public async Task<ActionResult> HistorialVentas(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            var paqueteDatos = await _ventaUseCase.EjecutarHistorial(buscarPor, numeroVenta, fechaInicio, fechaFin);

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
