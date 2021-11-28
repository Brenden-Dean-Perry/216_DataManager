using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace DataManager_216
{
    class DataAccess
    {

        public List<T> GetData_List<T>(string SQLquery, object Parameter_obj = null)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GeneralFormLibrary1.DatabaseAPI.ConnectionValue("QuantDB")))
            {

                if(Parameter_obj == null)
                {
                    return connection.Query<T>(SQLquery).ToList();
                }
                else
                {
                    return connection.Query<T>(SQLquery, Parameter_obj).ToList();
                }

            }
        }

    }
}
