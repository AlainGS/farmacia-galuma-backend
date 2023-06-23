using FarmaciaGaluma.Datos.Configuracion;
using FarmaciaGaluma.Datos.Entidades;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace FarmaciaGaluma.Datos.Repositorio
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly SettingConeccion _conexion;

        public EmpleadoRepositorio(IOptions<SettingConeccion> conexion)
        {
            _conexion = conexion.Value;
        }
        public async Task<List<Empleado>> ObtenerEmpleado()
        {
            List<Empleado> lista = new List<Empleado>();

            using (var conexion = new SqlConnection(_conexion.CadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("usp_app_listado_categoria", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var fila = await cmd.ExecuteReaderAsync())
                {
                    while(await fila.ReadAsync())
                    {
                        lista.Add(new Empleado()
                        {
                            EmpleadoID = Convert.ToInt32(fila["idCategoria"]),
                            Descripcion = fila["descripcionCategoria"].ToString(),
                            EsActivo = bool.Parse(fila["activoCategoria"].ToString()),
                            FechaRegistro = DateTime.Parse(fila["fechaCreateCategoria"].ToString())
                        });
                    }
                }
            }

            return lista;
        }
    }
}
