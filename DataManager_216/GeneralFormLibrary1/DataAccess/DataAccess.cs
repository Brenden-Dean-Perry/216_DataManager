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

        public static List<DataModels.Model_User> GetDataList_PI_Users()
        {
            List<GeneralFormLibrary1.DataModels.Model_User> model = GeneralFormLibrary1.DatabaseAPI.GetData_List<GeneralFormLibrary1.DataModels.Model_User>("Use Pi DECLARE @cnt INT = 0 WHILE @cnt < 10000000 BEGIN SET @cnt = @cnt + 1 END; Select * From Users;");
            return model;
        }

    }
}
