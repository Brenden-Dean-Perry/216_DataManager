using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GeneralFormLibrary1
{
    public class WebAPI
    {
        public static void LaunchURL(string URL)
        {
            System.Diagnostics.Process.Start(URL);
        }

        public static void Search(string searchString)
        {
            System.Diagnostics.Process.Start("https://www.google.com/search?q=" + searchString);
        }

    }
}
