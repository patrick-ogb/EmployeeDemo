using System;
using Employee.BO;
using System.Data;
using System.Data.SqlClient;


namespace Employee.DAL
{
    public  class GetSingleEmplyeeByIdFromDB
    {
        public EmployeeBO GetById(int Id)
        {
            SqlConnection con = null;
            EmployeeBO emp = null;
            try
            {
                con = AppCon.GetConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "spGetById";
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramId = new SqlParameter();
                paramId.Value = Id;
                paramId.ParameterName = "@Id";
                paramId.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(paramId);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    emp = new EmployeeBO();
                    emp.Id = Convert.ToInt32(rdr["Id"]);
                    emp.FirstName = rdr["FirstName"].ToString();
                    emp.LastName = rdr["LastName"].ToString();
                    emp.CompanyName = rdr["CompanyName"].ToString();
                }

            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Employee with Id ={emp.Id} does on exits in the database");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return emp;
        }
    }
}
