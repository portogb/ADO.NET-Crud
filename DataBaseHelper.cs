using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DataBaseHelper
    {
        // public static string ConnectionString = @"Data Source=master;
        //                                         User ID=SA;
        //                                         Password=saPassw@rd;
        //                                         Initial Catalog=Auto;
        //                                         Integrated Security=true";

        public static string ConnectionString = "Server=127.0.0.1,5434;Database=Auto;User ID=sa;Password=saPassw@rd;Trusted_Connection=False; TrustServerCertificate=True";
    }
}