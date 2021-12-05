using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFormLibrary1
{
    public class WebAPI
    {
        public static void Launch(string URL)
        {
            System.Diagnostics.Process.Start(URL);
        }
    }
}
