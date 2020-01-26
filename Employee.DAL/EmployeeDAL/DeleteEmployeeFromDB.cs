using System;
using Employee.BO;
using System.Data;
using System.Data.SqlClient;


namespace Employee.DAL
{   
        public class DeleteEmployeeFromDB
    {
            public bool DelectEmployee(int Id)
            {
                EmployeeBO emp = new EmployeeBO();
                SqlConnection con = null;
                bool status = false;
                try
                {
                    con = AppCon.GetConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "spDelete";
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlParameter paramId = new SqlParameter();
                    paramId.Value = Id;
                    paramId.ParameterName = "@Id";
                    paramId.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(paramId);

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
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                return status;
            }

        }
    
}
