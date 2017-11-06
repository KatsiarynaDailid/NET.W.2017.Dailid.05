using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class AppConfiguration
    {
        public static double Epsilon => Double.Parse(ConfigurationManager.AppSettings["Epsilon"]);
    }
}
