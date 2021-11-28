using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using System.Data;

namespace GeneralFormLibrary1
{
    public class DatabaseAPI
    {
        /// <summary>
        /// Returns connection string from your App.config file
        /// </summary>
        /// <param name="name">Name of connection per your App.config file</param>
        /// <returns></returns>
        public static string ConnectionValue(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> GetData_List<T>(string SQLquery, object Parameter_obj = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GeneralFormLibrary1.DatabaseAPI.ConnectionValue("PC")))
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

        public T GetData<T>(string SQLquery, object Parameter_obj = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GeneralFormLibrary1.DatabaseAPI.ConnectionValue("PC")))
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

        public async Task<List<T>> GetData_List_Async<T>(string SQLquery, object Parameter_obj = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GeneralFormLibrary1.DatabaseAPI.ConnectionValue("PC")))
            {
                IEnumerable<T> enumerable;
                if (Parameter_obj == null)
                {
                    enumerable = await connection.QueryAsync<T>(SQLquery).ConfigureAwait(false);
                }
                else
                {
                    enumerable = await connection.QueryAsync<T>(SQLquery, Parameter_obj).ConfigureAwait(false);
                }
                return enumerable.ToList<T>();
            }
        }

        public async Task<T> GetData_Async<T>(string SQLquery, object Parameter_obj = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GeneralFormLibrary1.DatabaseAPI.ConnectionValue("PC")))
            {
                IEnumerable<T> enumerable;
                if (Parameter_obj == null)
                {
                    enumerable = await connection.QueryAsync<T>(SQLquery).ConfigureAwait(false);
                }
                else
                {
                    enumerable = await connection.QueryAsync<T>(SQLquery, Parameter_obj).ConfigureAwait(false);  
                }

                return enumerable.FirstOrDefault<T>();
            }
        }

    }
}
