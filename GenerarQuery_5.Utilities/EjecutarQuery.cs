using GenerarQuery_5.MPP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarQuery_5.Utilities
{
    public static class EjecutarQuery
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MapeoDB"].ConnectionString;
        private static readonly IMapeo mapear = new MapeoGenerico();

        public static void ExecuteNonQuery(string query, Dictionary<string,object> properties = null)
        {
            using (SqlConnection sqlConnection = CrearConexion())
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                

                PasarPropiedades(properties, sqlCommand);

                sqlCommand.ExecuteNonQuery();
            }
        }

        private static void PasarPropiedades(Dictionary<string, object> properties, SqlCommand sqlCommand)
        {
            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    var propiedades = sqlCommand.CreateParameter();
                    propiedades.ParameterName = prop.Key;
                    propiedades.Value = prop.Value;
                    sqlCommand.Parameters.Add(propiedades);
                }
            }
        }


        public static IEnumerable<T> ExecuteSelectStatement<T>(string query, Dictionary<string,object> properties = null) where T: class, new()
        {
            using (SqlConnection sqlConnection = CrearConexion())
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                PasarPropiedades(properties, sqlCommand);
                sqlDataAdapter.Fill(dataSet);

                return dataSet.Tables[0].Rows.Cast<DataRow>().Select(mapear.Mapear<T>).ToList();

            }
        }

        private static SqlConnection CrearConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
