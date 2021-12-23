using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using System.Windows.Forms;

namespace GeneralFormLibrary1
{
    public class DataAccess<T> : IDataAccess<T> where T : class
    {
        private string DBConnection {get;}

        public DataAccess(Dictionary<string, string> credentials)
        {
            DBConnection = DatabaseAPI.ConnectionString("QuantDB", credentials);
        }

        public async Task<int> Insert(T entity, int CommandTimeout = 45)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.InsertAsync<T>(entity, commandTimeout: CommandTimeout);
                return output;
            }
        }

        public async Task<int> Insert(List<T> entity, int CommandTimeout = 45)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.InsertAsync<List<T>>(entity, commandTimeout: CommandTimeout);
                return output;
            }
        }

        public async Task<bool> Delete(T entity, int CommandTimeout = 45)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.DeleteAsync<T>(entity, commandTimeout: CommandTimeout);
                return output;
            }
        }

        public async Task<bool> Delete(List<T> entity, int CommandTimeout = 45)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.DeleteAsync<List<T>>(entity, commandTimeout: CommandTimeout);
                return output;
            }
        }

        public async Task<T> Get(int Id, int CommandTimeout = 45)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.GetAsync<T>(Id, commandTimeout: CommandTimeout);
                return output;
            }
        }

        public async Task<List<T>> GetAll(int CommandTimeout = 45)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.GetAllAsync<T>(commandTimeout: CommandTimeout);
                return output.ToList();
            }
        }

        public async Task<bool> Update(T entity, int CommandTimeout = 45)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {

                connection.Open();
                var output = await connection.UpdateAsync<T>(entity, commandTimeout: CommandTimeout);
                return output;
            }
        }

        public async Task<bool> Update(List<T> entity, int CommandTimeout = 45)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {

                connection.Open();
                var output = await connection.UpdateAsync<List<T>>(entity, commandTimeout: CommandTimeout);
                return output;
            }
        }

        public List<DataModels.Model_TableName> GetDatabaseTableNames()
        {
            List<DataModels.Model_TableName> model = DatabaseAPI.GetData_List<DataModels.Model_TableName>(DBConnection, "SELECT name[TableName] FROM sysobjects WHERE xtype = 'U' Order by name;");
            return model;
        }
    }
}
