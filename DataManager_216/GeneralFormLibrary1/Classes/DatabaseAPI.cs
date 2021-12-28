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
        public static List<T> GetData_List<T>(string ConnectionString, string SQLquery, object Parameter_obj = null, int ConnectionTimeout = 1200)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {

                if (Parameter_obj == null)
                {
                    return connection.Query<T>(SQLquery, commandTimeout: ConnectionTimeout).ToList();
                }
                else
                {
                    return connection.Query<T>(SQLquery, Parameter_obj, commandTimeout: ConnectionTimeout).ToList();
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
        internal static T GetData<T>(string ConnectionString, string SQLquery, object Parameter_obj = null, int ConnectionTimeout = 1200)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
 
                if (Parameter_obj == null)
                {
                    return connection.Query<T>(SQLquery, commandTimeout: ConnectionTimeout).FirstOrDefault<T>();
                }
                else
                {
                    return connection.Query<T>(SQLquery, Parameter_obj, commandTimeout: ConnectionTimeout).FirstOrDefault<T>();
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

        /// <summary>
        /// Query a particular table and return the implied data model class structure in a string
        /// </summary>
        /// <param name="connectionString">Database connection string</param>
        /// <param name="TableName">Database table name you want to model</param>
        /// <returns></returns>
        public static string BuildImpliedDataModel(string connectionString, DataModels.Model_TableName tableName)
        {
            string ClassName = String.Empty;
            StringBuilder sb = new StringBuilder();
            //Add table name
            sb.Append("[Table(\"" + tableName.TableName + "\")]");
            sb.Append(System.Environment.NewLine);

            //Add class name
            sb.Append("public class ");
            if (tableName.TableName.ToLower().EndsWith("s"))
            {
                ClassName = "Model_" + tableName.TableName.Substring(0, tableName.TableName.Length - 1);
            }
            else
            {
                ClassName = "Model_" + tableName.TableName;
            }
            sb.Append(ClassName);
            sb.Append(System.Environment.NewLine);

            //Class start
            sb.Append("{ ");
            sb.Append(System.Environment.NewLine);

            //Add properties
            string SQLquery = "Select C.name ColumnName, t.Name DataType, C.is_nullable IsNullable From sys.columns C Inner Join sys.types t on c.user_type_id = t.user_type_id Where c.object_id = OBJECT_ID(@TableName);";
            List <DataModels.Model_TableDataStructure> columns = GetData_List<DataModels.Model_TableDataStructure>(connectionString, SQLquery, tableName);
            foreach(DataModels.Model_TableDataStructure column in columns)
            {
                
                if(column.ColumnName.ToLower() == "id")
                {
                    sb.Append("\t");
                    sb.Append("[Key]");
                    sb.Append(System.Environment.NewLine);
                }
                else if (column.ColumnName.ToLower() == "createdate" || column.ColumnName.ToLower() == "changedate" || column.ColumnName.ToLower() == "createuser" || column.ColumnName.ToLower() == "changeuser")
                {
                    sb.Append("\t");
                    sb.Append("[Write(false)]");
                    sb.Append(System.Environment.NewLine);
                }

                sb.Append("\t");
                sb.Append("public ");

                if (DataTypes.ConvertSqlDataTypeToCSharpDataType(column.DataType).ToLower().Contains("date") || column.IsNullable)
                {
                    sb.Append(DataTypes.ConvertSqlDataTypeToCSharpDataType(column.DataType) + "? ");
                }
                else
                {
                    sb.Append(DataTypes.ConvertSqlDataTypeToCSharpDataType(column.DataType) + " ");
                }

                sb.Append(column.ColumnName + " ");
                sb.Append("{get; set;} ");
                sb.Append(System.Environment.NewLine);
            }

            //Add default constructor
            sb.Append(System.Environment.NewLine);
            sb.Append("\t public " + ClassName + "()");
            sb.Append(System.Environment.NewLine);
            sb.Append("\t{");
            sb.Append(System.Environment.NewLine);
            sb.Append("\t}");
            sb.Append(System.Environment.NewLine);
            sb.Append(System.Environment.NewLine);

            //Class end
            sb.Append("}");

            return sb.ToString();
        }


    }
}
