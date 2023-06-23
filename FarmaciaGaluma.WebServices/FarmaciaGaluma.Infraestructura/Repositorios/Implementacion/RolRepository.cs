using FarmaciaGaluma.Dominio.Entidades;
using FarmaciaGaluma.Dominio.Entidades.Comunes;
using FarmaciaGaluma.Utilidades.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace FarmaciaGaluma.Infraestructura.Repositorios.Implementacion
{
    public class RolRepository : IRolRepository
    {
        private readonly string _conectaDB;

        public RolRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }
               

        public Task<RARdata<List<BERol>>> ObtenerTodo()
        {
            return Task.Run(() =>
            {
                RARdata<List<BERol>> paqueteDatos = new RARdata<List<BERol>>();

                ArrayList alParameters = new ArrayList();

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_combo_rol", alParameters);

                    List<BERol> listaCategorias = new List<BERol>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BERol rol = new BERol();
                        rol.nro = int.Parse(row["nro"].ToString()!);
                        rol.RolID = int.Parse(row["IdRol"].ToString()!);
                        rol.RolNombre = row["NombreRol"].ToString()!;
                        

                        listaCategorias.Add(rol);
                    }

                    paqueteDatos.cuerpoData = listaCategorias;
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
                       

    }
}
