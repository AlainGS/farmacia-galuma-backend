using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Utilidades.Utils;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace FarmaciaGaluma.Infraestructura.Repositorios.Implementacion
{
    public class MenuRepository : IMenuRepository
    {
        private readonly string _conectaDB;

        public MenuRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }
                
        public Task<RARdata<List<BEMenu>>> ListadoMenu(int idUsuario)
        {
            return Task.Run(() =>
            {
                RARdata<List<BEMenu>> paqueteDatos = new RARdata<List<BEMenu>>();

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                parameter = new SqlParameter("@IdUsuario", SqlDbType.Int);
                parameter.Value = idUsuario;
                alParameters.Add(parameter);

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_listado_menu", alParameters);

                    List<BEMenu> listaMenus = new List<BEMenu>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEMenu menu = new BEMenu();
                        menu.MenuID = int.Parse(row["IdMenu"].ToString()!);
                        menu.MenuDescripcion = row["DescripcionMenu"].ToString()!;
                        menu.MenuIcono = row["IconoMenu"].ToString()!;
                        menu.MenuUrl = row["UrlMenu"].ToString()!;
                        listaMenus.Add(menu);
                    }

                    paqueteDatos.cuerpoData = listaMenus;
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


    }
}
