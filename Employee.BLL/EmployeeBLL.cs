using System.Collections.Generic;
using Employee.BO;
using Employee.DAL;
namespace Employee.BLL
{
    public class EmployeeBLL
    {

        EmployeeDAL dal = new EmployeeDAL();

        public int AddEmployeeBLL(EmployeeBO employee)
        {
            return dal.AddEmployee(employee);
        }

        GetSingleEmplyeeByIdFromDB getSingleEmployeeByIdFromDB = new GetSingleEmplyeeByIdFromDB();
        public EmployeeBO GetEmployeeById(int Id)
        {
            return getSingleEmployeeByIdFromDB.GetById(Id);
        
        }
        GetAllEmployees getAllEmployees = new GetAllEmployees();
        public List<EmployeeBO> GetALLEmployee()
        {
            return getAllEmployees.GetALL();
        }

        public bool UpdateEmployeeBLL(EmployeeBO employee)
        {
            return UpdateEmployeeInDB.UpdateEmployee(employee);
        }

        DeleteEmployeeFromDB deleteEmployeeFromDB = new DeleteEmployeeFromDB();
        public bool DeleteEmployeeBLL(int Id)
        {
            return deleteEmployeeFromDB.DelectEmployee(Id);
        }

    }
    
}