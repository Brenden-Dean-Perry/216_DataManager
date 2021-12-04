using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;

namespace GeneralFormLibrary1
{
    public class DatabaseAPI
    {
        /// <summary>
        /// Returns connection string from your App.config file
        /// </summary>
        /// <param name="connectionName">Name of connection per your App.config file</param>
        /// <returns></returns>
        public static string ConnectionString(string connectionName, Dictionary<string, string> credentials = null)
        {
            if(credentials is null)
            {
                return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            }
            else
            {
                return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.Replace("/***username***/", credentials["username"]).Replace("/***password***/", credentials["password"]);
            }

            
        }

        /// <summary>
        /// Returns queried data from a database
        /// </summary>
        /// <typeparam name="T">Generic Object</typeparam>
        /// <param name="ConnectionString">Database connection string</param>
        /// <param name="SQLquery">SQL query. Make sure you include a "Use" statement</param>
        /// <param name="Parameter_obj">Parameter object</param>
        /// <returns></returns>
        internal static List<T> GetData_List<T>(string ConnectionString, string SQLquery, object Parameter_obj = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {

                if (Parameter_obj == null)
                {
                    return connection.Query<T>(SQLquery).ToList();
                }
                else
                {
                    return connection.Query<T>(SQLquery, Parameter_obj).ToList();
                }

            }
        }
        /// <summary>
        /// Returns queried data from a database
        /// </summary>
        /// <typeparam name="T">Generic Object</typeparam>
        /// <param name="ConnectionString">Database connection string</param>
        /// <param name="SQLquery">SQL query. Make sure you include a "Use" statement</param>
        /// <param name="Parameter_obj">Parameter object</param>
        /// <returns></returns>
        internal static T GetData<T>(string ConnectionString, string SQLquery, object Parameter_obj = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {

                if (Parameter_obj == null)
                {
                    return connection.Query<T>(SQLquery).FirstOrDefault<T>();
                }
                else
                {
                    return connection.Query<T>(SQLquery, Parameter_obj).FirstOrDefault<T>();
                }
            }
        }

        /// <summary>
        /// Test whether connection to database can be made
        /// </summary>
        /// <param name="connectionString">Database connection string</param>
        /// <returns></returns>
        public static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

    }
}
