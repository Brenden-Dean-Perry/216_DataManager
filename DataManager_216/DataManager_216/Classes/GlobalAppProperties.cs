using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager_216
{

    public class GlobalAppProperties
    {
        public static string AppName = "216";
        public static string Username { get; set; }
        public static string Password { get; set; }

        public static string Directroy_Downloads { get; } = @"C:\Users\"+Environment.UserName+ @"\Downloads";

        public static Dictionary<string, string> GetCredentials()
        {
            Dictionary<string, string> credentials = new Dictionary<string, string>();
            credentials.Add("username", Username);
            credentials.Add("password", Password);

            return credentials;
        }

    }
}
