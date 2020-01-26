using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee;

namespace Employee.DAL
{
  public  class AppCon
    {
        public static SqlConnection GetConnection()
        {

            string CS = "Server=(localdb)\\MSSQLLocalDB; Database=SimpleDB; integrated security=true;";
            SqlConnection con = new SqlConnection(CS);
            return con;
        }
    }
}
