using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EmployeeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            AddEmployeeDetailsToDB addEmployeeDetailsToDB = new AddEmployeeDetailsToDB();
            addEmployeeDetailsToDB.AddEmployeeDetails();

            //GetAllEmployeesDetails getAll = new GetAllEmployeesDetails();
            //getAll.GetEmployees();

            //GetSingleEmployeeById getById = new GetSingleEmployeeById();
            //getById.GetEmployeeById();

            //UpdateEmployeeInDB updateEmployee = new UpdateEmployeeInDB();
            //updateEmployee.UpdateEmployee();

           // DeleteEmployeeFromDB deleteEmployee = new DeleteEmployeeFromDB();
           // deleteEmployee.DeleteEmployee();
        }
    }
}
