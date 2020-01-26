using System;
using Employee.BLL;



namespace EmployeeDemo
{
    public class GetSingleEmployeeById
    {
        public void GetEmployeeById()
        {

            EmployeeBLL Ebll = new EmployeeBLL();
            Console.Write("Pls, enter Employee Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            var employee = Ebll.GetEmployeeById(Id);

            Console.WriteLine(employee.ToString());

        }
    }
}
