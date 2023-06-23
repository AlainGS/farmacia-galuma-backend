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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaUseCase _categoriaUseCase;

        public CategoriaController(ICategoriaUseCase categoriaUseCase)
        {
            _categoriaUseCase = categoriaUseCase;
        }

        #region LISTAR MUCHOS REGISTROS
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Listado()
        {
            var paqueteDatos = await _categoriaUseCase.EjecutarObtenerTodo();

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
        public Task<ActionResult> Post(BECategoria entity)
        {
            return guardarCambios(1, entity); //accion 1 = insertar
        }

        [HttpPut("{accion}")]
        public Task<ActionResult> Put(int accion, BECategoria entity)
        {
            return guardarCambios(accion, entity); //accion 2 = actualizar; accion 3 = eliminar
        }

        private async Task<ActionResult> guardarCambios(int accion, BECategoria entity)
        {
            var paqueteDatos = await _categoriaUseCase.EjecutarCreaEditaElimina(entity, accion);
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
