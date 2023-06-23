using System.Collections;
using System.Data;
using System.Data.SqlClient;

//DataSet -> UNA BASE DE DATOS COMPLETA
//DataTable -> UNA TABLA COMPLETA de la base de datos
//DataColumn -> UNA COLUMNA COMPLETA de una tabla especifica
//DataRow -> UNA FILA COMPLETA de una tabla especifica

namespace FarmaciaGaluma.Utilidades.Utils
{
    public class SqlComandos
    {
        public static DataSet getDataSetSP(String cnx, string spName, ArrayList alParametros)
        {
            DataSet ds = null;
            using (SqlConnection connection = new SqlConnection(cnx))
            {
                connection.Open();
                SqlCommand cmd = getCommand(connection, spName, alParametros);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            if (ds == null)
                throw new Exception("Error de consulta, la consulta no devolvió ningún resultado");
            return ds;
        }

        public static DataSet getDataSetQuery(String cnx, string sql)
        {
            DataSet ds = null;
            using (SqlConnection connection = new SqlConnection(cnx))
            {
                connection.Open();
                SqlCommand cmd = getCommand(connection, sql);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            if (ds == null)
                throw new Exception("Error de consulta, la consulta no devolvió ningún resultado");
            return ds;
        }

        public static DataTable getDataTableSP(String cnx, string spName, ArrayList alParametros)
        {
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(cnx))
            {
                connection.Open();
                SqlCommand cmd = getCommand(connection, spName, alParametros);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                dt = new DataTable();
                adaptador.Fill(dt);
            }
            if (dt == null)
                throw new Exception("Error de consulta, la consulta no devolvió ningún resultado");
            return dt;
        }

        public static DataTable getDataTableQuery(String cnx, string sql)
        {
            DataTable dt = null;
            using (SqlConnection connection = new SqlConnection(cnx))
            {
                connection.Open();
                SqlCommand cmd = getCommand(connection, sql);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            if (dt == null)
                throw new Exception("Error de consulta, la consulta no devolvió ningún resultado");
            return dt;
        }

        private static SqlCommand getCommand(SqlConnection conn, string spName, ArrayList alParametros)
        {
            SqlCommand cmd = new SqlCommand(spName, conn);
            IEnumerator ieParametros = alParametros.GetEnumerator();
            while (ieParametros.MoveNext())
            { cmd.Parameters.Add((SqlParameter)ieParametros.Current); }
            return cmd;
        }
        

        private static SqlCommand getCommand(SqlConnection conn, string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd;
        }
        public static bool executeReaderSP(String cnx, string sql, ArrayList alParametros, out string mensajeSQL)
        {
            bool rpta;
            using (SqlConnection connection = new SqlConnection(cnx))
            {
                connection.Open();
                SqlCommand cmd = getCommand(connection, sql, alParametros);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataReader obj = cmd.ExecuteReader();
                obj.Read();
                string vExito = obj.GetString(0);

                rpta = MensajesDesdeSQL.CodigoRetorno(vExito, out mensajeSQL);
                obj.Close();
            }
            return rpta;
        }

        //public static SqlCommand getCommandP(SqlConnection conn, string spName, ArrayList alParametros)
        //{
        //    SqlCommand cmd = new SqlCommand(spName, conn);
        //    IEnumerator ieParametros = alParametros.GetEnumerator();
        //    while (ieParametros.MoveNext())
        //    { cmd.Parameters.Add((SqlParameter)ieParametros.Current); }
        //    return cmd;
        //}

        //public static bool publicDatatable(string cnx, DataTable DT, string table_name)
        //{

        //    SqlConnection conn = getConnection(cnx);

        //    SqlBulkCopy sqlBC = new SqlBulkCopy(conn);

        //    sqlBC.DestinationTableName = table_name; //Nombre de la Tabla a Cargar
        //    sqlBC.WriteToServer(DT);

        //    conn.Close();

        //    return DT.Rows.Count > 0;
        //}


        ////-------------------------------------------------------------------------------------------------------------
        //public static object executeScalar(String cnx, string sql, ArrayList alParametros)
        //{
        //    object obj = null;
        //    using (SqlConnection connection = new SqlConnection(cnx))
        //    {
        //        connection.Open();
        //        SqlCommand cmd = getCommand(connection, sql, alParametros);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 0;
        //        obj = cmd.ExecuteScalar();
        //    }
        //    if (obj == null)
        //        throw new Exception("Error de transacción, la ejecución no devolvió ningún resultado");
        //    return obj;
        //}


        //public static int executeNonQuery(String cnx, string spName, ArrayList alParametros)
        //{
        //    int res;
        //    using (SqlConnection connection = new SqlConnection(cnx))
        //    {
        //        connection.Open();
        //        SqlCommand cmd = getCommand(connection, spName, alParametros);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 0;
        //        res = cmd.ExecuteNonQuery();
        //    }
        //    return res;
        //}

        //public static int executeNonQueryText(String cnx, string sqlQuery)
        //{
        //    int res;
        //    using (SqlConnection connection = new SqlConnection(cnx))
        //    {
        //        connection.Open();
        //        SqlCommand cmd = getCommand(connection, sqlQuery);
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandTimeout = 0;
        //        res = cmd.ExecuteNonQuery();
        //    }
        //    return res;
        //}

        //public static SqlConnection getConnection(String strcnx)
        //{
        //    SqlConnection conn = new SqlConnection(SqlConexionFarmacia.CadenaSQL);
        //    conn.Open();
        //    //Console.WriteLine("Conexion: ", conn);
        //    return conn;
        //}
    }
}
