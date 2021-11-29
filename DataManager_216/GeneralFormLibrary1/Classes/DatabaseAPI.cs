using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using System.Data;
using System.ComponentModel;

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

        public static List<T> GetData_List<T>(string SQLquery, object Parameter_obj = null)
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

        public static T GetData<T>(string SQLquery, object Parameter_obj = null)
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

    }
}
