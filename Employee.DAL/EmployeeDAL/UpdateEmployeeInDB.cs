using System;
using Employee.BO;
using System.Data;
using System.Data.SqlClient;


namespace Employee.DAL
{
    public class UpdateEmployeeInDB 
    {
        public static bool UpdateEmployee(EmployeeBO employee)
        {
            bool status = false;
            SqlConnection conn = null;
            try
            {
                conn = AppCon.GetConnection();
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                paramId.SqlDbType = SqlDbType.Int;
                paramId.Size = 50;
                cmd.Parameters.Add(paramId);

                SqlParameter paraFirstName = new SqlParameter();
                paraFirstName.ParameterName = "@FirstName";
                paraFirstName.Value = employee.FirstName;
                paraFirstName.SqlDbType = SqlDbType.NVarChar;
                paraFirstName.Size = 50;
                cmd.Parameters.Add(paraFirstName);

                SqlParameter paramLastName = new SqlParameter();
                paramLastName.ParameterName = "@LastName";
                paramLastName.Value = employee.LastName;
                paramLastName.SqlDbType = SqlDbType.NVarChar;
                paramLastName.Size = 50;
                cmd.Parameters.Add(paramLastName);

                SqlParameter paramCompanyName = new SqlParameter();
                paramCompanyName.ParameterName = "@CompanyName";
                paramCompanyName.Value = employee.CompanyName;
                paramCompanyName.SqlDbType = SqlDbType.NVarChar;
                paramCompanyName.Size = 50;
                cmd.Parameters.Add(paramCompanyName);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
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
            return status;
        }
    }
}
