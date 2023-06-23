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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _conectaDB;

        public CategoriaRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }


        public Task<RARdata<List<BECategoria>>> ObtenerTodo()
        {
            return Task.Run(() =>
            {
                RARdata<List<BECategoria>> paqueteDatos = new RARdata<List<BECategoria>>();

                ArrayList alParameters = new ArrayList();

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_listado_categoria", alParameters);

                    List<BECategoria> listaCategorias = new List<BECategoria>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BECategoria categoria = new BECategoria();
                        categoria.nro = int.Parse(row["nro"].ToString()!);
                        categoria.CategoriaID = int.Parse(row["IdCategoria"].ToString()!);
                        categoria.FiltroID = int.Parse(row["IdFiltro"].ToString()!);
                        categoria.CategoriaDescripcion = row["DescripcionCategoria"].ToString()!;
                        categoria.CategoriaEstado = bool.Parse(row["EstadoCategoria"].ToString()!);

                        listaCategorias.Add(categoria);
                    }

                    //************************************** IMPORTANTE ***********
                    paqueteDatos.cuerpoData = listaCategorias;
                    paqueteDatos.estadoData = 1;
                    //*************************************************************
                }
                catch (Exception ex)
                {
                    paqueteDatos.estadoData = -1;
                    paqueteDatos.mensajeData = MensajesDeError.ERROR_INESPERADO_LIST + ex.Message;
                }

                return paqueteDatos;
            });
        }


        public Task<RARdata<BECategoria>> CreaEditaElimina(BECategoria categoria, int accion)
        {
            return Task.Run(() =>
            {
                RARdata<BECategoria> paqueteDatos = new RARdata<BECategoria>();
                string mensajeDesdeSQLServer = "";

                ArrayList alParameters = new ArrayList();
                SqlParameter parameter;

                parameter = new SqlParameter("@IdCategoria", SqlDbType.Int);
                parameter.Value = categoria.CategoriaID;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@IdFiltro", SqlDbType.Int);
                parameter.Value = categoria.FiltroID;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@DescripcionCategoria", SqlDbType.VarChar, 200);
                parameter.Value = categoria.CategoriaDescripcion;
                alParameters.Add(parameter);

                parameter = new SqlParameter("@EstadoCategoria", SqlDbType.Bit);
                parameter.Value = categoria.CategoriaEstado;
                alParameters.Add(parameter);

                if (accion == 3)
                {
                    var codigos = new
                    {
                        id = categoria.CategoriaID.ToString()
                    };

                    parameter = new SqlParameter("@jsonCodigos", SqlDbType.NVarChar);
                    parameter.Value = JsonConvert.SerializeObject(codigos);
                    alParameters.Add(parameter);
                }

                parameter = new SqlParameter("@Accion", SqlDbType.Int);
                parameter.Value = accion;
                alParameters.Add(parameter);

                //parameter = new SqlParameter("@Login", SqlDbType.VarChar, 20);
                //parameter.Value = categoria.comedorUsuario;
                //alParameters.Add(parameter);

                try
                {
                    paqueteDatos.estadoData = SqlComandos.executeReaderSP(_conectaDB, "usp_app_crea_edita_elimina_categoria", alParameters, out mensajeDesdeSQLServer) ? 1 : 0;
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
