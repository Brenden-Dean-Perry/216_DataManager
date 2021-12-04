using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.ComponentModel;

namespace GeneralFormLibrary1
{
    public static class DataAccess
    {


        public static List<DataModels.Model_User> GetDataList_PI_Users_quick()
        {
            List<GeneralFormLibrary1.DataModels.Model_User> model = GeneralFormLibrary1.DatabaseAPI.GetData_List<GeneralFormLibrary1.DataModels.Model_User>(GeneralFormLibrary1.DatabaseAPI.ConnectionString("PIDB"),"Use Pi Select * From Users;");
            return model;
        }

        public static List<DataModels.Model_User> GetDataList_PI_Users()
        {
            List<GeneralFormLibrary1.DataModels.Model_User> model = GeneralFormLibrary1.DatabaseAPI.GetData_List<GeneralFormLibrary1.DataModels.Model_User>(GeneralFormLibrary1.DatabaseAPI.ConnectionString("PIDB"),"Use Pi DECLARE @cnt INT = 0 WHILE @cnt < 10000000 BEGIN SET @cnt = @cnt + 1 END; Select * From Users;");
            return model;
        }

        public static List<DataModels.Model_TableName> GetDatabaseTableNames_PI()
        {
            List<GeneralFormLibrary1.DataModels.Model_TableName> model = GeneralFormLibrary1.DatabaseAPI.GetData_List<GeneralFormLibrary1.DataModels.Model_TableName>(GeneralFormLibrary1.DatabaseAPI.ConnectionString("PIDB"),"Use Pi SELECT name[TableName] FROM sysobjects WHERE xtype = 'U' Order by name;");
            return model;
        }

        public static List<DataModels.Model_User> GetDataList_Quant_Users(Dictionary<string, string> dbCredentials)
        {
            List<GeneralFormLibrary1.DataModels.Model_User> model = GeneralFormLibrary1.DatabaseAPI.GetData_List<GeneralFormLibrary1.DataModels.Model_User>(GeneralFormLibrary1.DatabaseAPI.ConnectionString("QuantDB", dbCredentials),"Select * From Users;");
            return model;
        }


    }
}
