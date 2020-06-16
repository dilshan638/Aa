using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegBackEndNew.DataAccess
{
    public class DBConnection
    {
        public DBConnection()
        {

        }
        public static SqlConnection DBConn()
            
        {
            SqlConnection con = new SqlConnection("Server=(local); Database=RGT;Trusted_Connection=True; MultipleActiveResultSets=True;");
            return con;
        }
    }
}
