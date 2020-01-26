using System;
using Employee.BO;
using Employee.BLL;



namespace EmployeeDemo
{
    public class UpdateEmployeeInDB
    {
        public void UpdateEmployee()
        {
            EmployeeBO employee = new EmployeeBO();
            EmployeeBLL Ebll = new EmployeeBLL();

            Console.Write("Pls, enter Employee Id: ");
            employee.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Pls, enter Employee First Name: ");
            employee.FirstName = Console.ReadLine();

            Console.Write("Pls enter Employee Last Name: ");
            employee.LastName = Console.ReadLine();

            Console.Write("Pls enter Company name: ");
            employee.CompanyName = Console.ReadLine();
            Ebll.UpdateEmployeeBLL(employee);
        }
    }
}
