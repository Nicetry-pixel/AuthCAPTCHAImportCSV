using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthCAPTCHAImportCSV
{
    internal class GlobalConfig
    {
        public static string ConnectionString { get; set; } =
            "Server=localhost;Database=tradeautoproduct;Uid=root;Pwd=root123;";

        public static int UserRole { get; set; } = 0;
        public static string UserFIO { get; set; } = "";
        public static bool IsGuest { get; set; } = false;
        public static int InactivitySeconds { get; set; } = 600;
    }
}
