using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Utilidades.Utils;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace FarmaciaGaluma.Infraestructura.Repositorios.Implementacion
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _conectaDB;

        public UsuarioRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }

        public Task<RARdata<BESesion>> ValidarCredenciales(string correo, string clave)
        {
            return Task.Run(() =>
            {
                RARdata<BESesion> paqueteDatos = new RARdata<BESesion>();

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                parameter = new SqlParameter("@Correo", SqlDbType.VarChar, 40);
                parameter.Value = correo;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@Clave", SqlDbType.VarChar, 40);
                parameter.Value = clave;
                alParameters.Add(parameter);

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_validar_usuario", alParameters);

                    BESesion usuario = new BESesion();
                    foreach (DataRow row in dt.Rows)
                    {
                        usuario.UsuarioID = int.Parse(row["IdUsuario"].ToString()!);
                        usuario.UsuarioNombre = row["NombreUsuario"].ToString()!;
                        usuario.UsuarioCorreo = row["CorreoUsuario"].ToString()!;
                        usuario.RolNombre = row["NombreRol"].ToString()!;
                    }

                    paqueteDatos.cuerpoData = usuario;
                    paqueteDatos.estadoData = 1;
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_GET + ex.Message;
                }

                return paqueteDatos;
            });
        }

        public Task<RARdata<List<BEUsuario>>> ObtenerTodo()
        {
            return Task.Run(() =>
            {
                RARdata<List<BEUsuario>> paqueteDatos = new RARdata<List<BEUsuario>>();

                ArrayList alParameters = new ArrayList();

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_listado_usuario", alParameters);

                    List<BEUsuario> listaUsuario = new List<BEUsuario>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEUsuario usuario = new BEUsuario();
                        usuario.nro = int.Parse(row["nro"].ToString()!);
                        usuario.UsuarioID = int.Parse(row["IdUsuario"].ToString()!);
                        usuario.UsuarioNombre = row["NombreUsuario"].ToString()!;
                        usuario.RolID = int.Parse(row["IdRol"].ToString()!);
                        usuario.RolNombre = row["NombreRol"].ToString()!;
                        usuario.UsuarioCorreo = row["CorreoUsuario"].ToString()!;
                        usuario.UsuarioClave = row["ClaveUsuario"].ToString()!;
                        usuario.UsuarioEstado = bool.Parse(row["EstadoUsuario"].ToString()!) ? 1 : 0;

                        listaUsuario.Add(usuario);
                    }

                    paqueteDatos.cuerpoData = listaUsuario;
                    paqueteDatos.estadoData = 1;
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_LIST + ex.Message;
                }

                return paqueteDatos;
            });
        }


        public Task<RARdata<BEUsuario>> CreaEditaElimina(BEUsuario usuario, int accion)
        {
            return Task.Run(() =>
            {
                RARdata<BEUsuario> paqueteDatos = new RARdata<BEUsuario>();
                string mensajeDesdeSQLServer = "";

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                parameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
                parameter.Value = usuario.UsuarioID;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@NombreUsuario", SqlDbType.VarChar, 200);
                parameter.Value = usuario.UsuarioNombre;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@IdRol", SqlDbType.Int);
                parameter.Value = usuario.RolID;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@CorreoUsuario", SqlDbType.VarChar, 200);
                parameter.Value = usuario.UsuarioCorreo;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@ClaveUsuario", SqlDbType.VarChar, 200);
                parameter.Value = usuario.UsuarioClave;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@EstadoUsuario", SqlDbType.Bit);
                parameter.Value = usuario.UsuarioEstado;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@User", SqlDbType.VarChar, 20);
                parameter.Value = usuario.user;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@Pc", SqlDbType.VarChar, 20);
                parameter.Value = usuario.pc;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@Accion", SqlDbType.Int);
                parameter.Value = accion;
                alParameters.Add(parameter);
                                
                try
                {
                    paqueteDatos.estadoData = SqlComandos.executeReaderSP(_conectaDB, "usp_app_crea_edita_elimina_usuario", alParameters, out mensajeDesdeSQLServer) ? 1 : 0;
                    paqueteDatos.mensajeData = mensajeDesdeSQLServer;
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_SAVE_UPDATE + ex.Message;
                }

                return paqueteDatos;
            });
        }

    }
}
