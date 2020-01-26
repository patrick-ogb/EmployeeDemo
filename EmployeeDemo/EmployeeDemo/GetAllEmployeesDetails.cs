using System;
using System.Collections.Generic;
using Employee.BO;
using Employee.BLL;



namespace EmployeeDemo
{
    public class GetAllEmployeesDetails
    {
        public void GetEmployees()
        {
            EmployeeBLL bll = new EmployeeBLL();
            List<EmployeeBO> employees = bll.GetALLEmployee();
            foreach (EmployeeBO emp in employees)
            {
                Console.WriteLine();
                Console.WriteLine(emp.ToString());
            }
        }
    }
}
