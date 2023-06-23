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
    public class BoletaRepository : IBoletaRepository
    {
        private readonly string _conectaDB;

        public BoletaRepository()
        {
            _conectaDB = SqlConexionFarmacia.CadenaSQL;
        }
               

        public Task<RARdata<BEBoleta>> UltimoNumeroDoc()
        {
            int cantidadDigitos = 4;
            string ceros = "0000";

            return Task.Run(() =>
            {
                RARdata<BEBoleta> paqueteDatos = new RARdata<BEBoleta>();

                ArrayList alParameters = new ArrayList();

                try
                {
                    DataTable dt = new DataTable();
                    dt = SqlComandos.getDataTableSP(_conectaDB, "usp_app_ultimo_numero_boleta", alParameters);

                    List<BEBoleta> listaNumeroDocumento = new List<BEBoleta>();
                    foreach (DataRow row in dt.Rows)
                    {
                        BEBoleta numDoc = new BEBoleta();
                            int tempUltNum = int.Parse(row["UltimoNumero"].ToString()!);
                                tempUltNum = tempUltNum + 1;
                            string  newNumeroVenta = ceros + tempUltNum;
                                    newNumeroVenta = newNumeroVenta.Substring(newNumeroVenta.Length - cantidadDigitos);
                        
                        numDoc.BoletaID = int.Parse(row["IdBoleta"].ToString()!);
                        numDoc.UltimoNumeroDoc = newNumeroVenta;


                        listaNumeroDocumento.Add(numDoc);
                    }

                    paqueteDatos.cuerpoData = listaNumeroDocumento[0];
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
