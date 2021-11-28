using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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

    }
}
