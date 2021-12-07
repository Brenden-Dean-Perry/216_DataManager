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

        public async Task<int> Add(T entity)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.InsertAsync<T>(entity);
                return output;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.DeleteAsync<T>(entity);
                return output;
            }
        }

        public async Task<T> Get(int Id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.GetAsync<T>(Id);
                return output;
            }
        }

        public async Task<List<T>> GetAll()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {
                connection.Open();
                var output = await connection.GetAllAsync<T>();
                return output.ToList();
            }
        }

        public async Task<bool> Update(T entity)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DBConnection))
            {

                connection.Open();
                var output = await connection.UpdateAsync<T>(entity);
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
