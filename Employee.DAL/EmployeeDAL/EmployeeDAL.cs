using System;
using Employee.BO;
using System.Data;
using System.Data.SqlClient;


namespace Employee.DAL
{
    public partial class EmployeeDAL
    {
        public int AddEmployee(EmployeeBO employee)
        {
            bool status = false;
            int Empid = 0;
            SqlConnection conn = null;
            try
            {
                conn = AppCon.GetConnection();
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "spInsertIntoEmployee";
                cmd.CommandType = CommandType.StoredProcedure;

                
                SqlParameter paraFirstName = new SqlParameter();
                paraFirstName.ParameterName = "@FirstName";
                paraFirstName.Value = employee.FirstName;
                paraFirstName.SqlDbType = SqlDbType.NVarChar;
                paraFirstName.Size = 100;
                cmd.Parameters.Add(paraFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@LastName";
                paramLastName.Value = employee.LastName;
                paramLastName.SqlDbType = SqlDbType.NVarChar;
                paramLastName.Size = 100;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramCompanyName = new SqlParameter();
                paramCompanyName.ParameterName = "@CompanyName";
                paramCompanyName.Value = employee.CompanyName;
                paramCompanyName.SqlDbType = SqlDbType.NVarChar;
                paramCompanyName.Size = 100;
                cmd.Parameters.Add(paramCompanyName);

                SqlParameter paramEmployeeIdOut = new SqlParameter();
                paramEmployeeIdOut.ParameterName = "@EmpoyeeId";
                paramEmployeeIdOut.SqlDbType = SqlDbType.Int;
                paramEmployeeIdOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramEmployeeIdOut);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                employee.Id = Convert.ToInt32(paramEmployeeIdOut.Value);
                if (result > 0)
                    status = true;

            }
            catch (Exception e)
            {

                e.ToString();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

            }
            return employee.Id ;
        }
    }
}
