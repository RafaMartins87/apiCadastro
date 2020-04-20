using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Common
{
    public class Base
    {
        public static string TIPOBANCO { get; set; }
        public static string STRINGCONEXAO { get; set; }
    }

    public class ApiUrl
    {
        public static string BASEIP { get; set; }
        public static string APIBARRAMENTO { get; set; }
        public static string APIRECEBIMENTOREAD { get; set; }
    }
}
