using System;
using Employee.BO;
using Employee.BLL;



namespace EmployeeDemo
{
    public class DeleteEmployeeFromDB
    {
        public void DeleteEmployee()
        {
            EmployeeBLL Ebll = new EmployeeBLL();
            Console.Write("Pls, enter Employee Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Ebll.DeleteEmployeeBLL(Id);
        }
    }
}
