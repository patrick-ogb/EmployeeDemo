using System;
using Employee.BO;
using Employee.BLL;



namespace EmployeeDemo
{
    public class AddEmployeeDetailsToDB
    {
        public void AddEmployeeDetails()
        {
            EmployeeBO employee = new EmployeeBO();
            EmployeeBLL bll = new EmployeeBLL();

            Console.Write("Pls, enter Employee First Name: ");
            employee.FirstName = Console.ReadLine();

            Console.Write("Pls enter Employee Last Name: ");
            employee.LastName = Console.ReadLine();

            Console.Write("Pls enter Company name: ");
            employee.CompanyName = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(employee.FirstName) && !String.IsNullOrWhiteSpace(employee.LastName)
                && !String.IsNullOrWhiteSpace(employee.CompanyName))
            {
                bll.AddEmployeeBLL(employee);
            }
            else
            {
                Console.WriteLine("All fields required / empty strings or white spaces are not allowed");
            }
        }
    }
}
