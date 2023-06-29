using FarmaciaGaluma.Aplicacion.UseCases;
using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Utilidades.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FarmaciaGaluma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoUseCase _productoUseCase;

        public ProductoController(IProductoUseCase productoUseCase)
        {
            _productoUseCase = productoUseCase;
        }

        #region LISTAR MUCHOS REGISTROS
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> Listado()
        {
            var paqueteDatos = await _productoUseCase.EjecutarObtenerTodo();

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
        public Task<ActionResult> Post(BEProducto entity)
        {
            return guardarCambios(1, entity); //accion 1 = insertar
        }

        [HttpPut("{accion}")]
        public Task<ActionResult> Put(int accion, BEProducto entity)
        {
            return guardarCambios(accion, entity); //accion 2 = actualizar; accion 3 = eliminar
        }

        private async Task<ActionResult> guardarCambios(int accion, BEProducto entity)
        {
            var paqueteDatos = await _productoUseCase.EjecutarCreaEditaElimina(entity, accion);
            if (paqueteDatos.estadoData != -1)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));
        }
        #endregion

        #region ConsultarProductoIBMWatson
        [HttpGet]
        [Route("{descripcion}")]
        public async Task<ActionResult> ConsultarProducto(string descripcion)
        {
            var paqueteDatos = await _productoUseCase.EjecutarConsultarProductoXdescripcion(descripcion);

            if (paqueteDatos != null)
            {
                paqueteDatos.estadoData = paqueteDatos.estadoData == 1 ? 200 : 400;
                return Ok(paqueteDatos);
            }
            else
                return BadRequest(new WebApiError(500, HttpStatusCode.BadRequest.ToString(), paqueteDatos.mensajeData));
            //try
            //{
            //    var paqueteDatos = await _productoUseCase.EjecutarConsultarProductoXdescripcion(descripcion);
            //    return Ok(paqueteDatos);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new WebApiError(400, HttpStatusCode.BadRequest.ToString(), ex.Message));
            //}
        }
        #endregion

    }
}
