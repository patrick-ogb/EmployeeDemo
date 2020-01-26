using System;
using System.Collections.Generic;
using Employee.BO;
using System.Data;
using System.Data.SqlClient;
//using System.Web.Script.Serialization;

namespace Employee.DAL
{
    public class GetAllEmployees
    {
        public List<EmployeeBO> GetALL()
        {
            SqlConnection con = null;
            List<EmployeeBO> listemployees = new List<EmployeeBO>();

            try
            {
                con = AppCon.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeBO emp = new EmployeeBO();

                    emp.Id = Convert.ToInt32(rdr["Id"]);
                    emp.FirstName = rdr["FirstName"].ToString();
                    emp.LastName = rdr["LastName"].ToString();
                    emp.CompanyName = rdr["CompanyName"].ToString();
                    listemployees.Add(emp);
                }
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //js.Serialize(listemployees);
            }
            catch (Exception e)
            {

                e.ToString();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return listemployees;
        }
    }
}
