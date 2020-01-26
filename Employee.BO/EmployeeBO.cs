using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.BO
{
    public class EmployeeBO
    {
        private int _id;

        public int Id
        {
            get
            { return _id; }
            set { _id = value; }
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private string _companyName;

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public override string ToString()
        {
            StringBuilder bdr = new StringBuilder();
            bdr.AppendLine(String.Format($"  Employee Id: {Id} "));
            bdr.AppendLine(String.Format($"  Employee FirstName: {FirstName} "));
            bdr.AppendLine(String.Format($"  Employee LastName: {LastName} "));
            bdr.AppendLine(String.Format($"  Employee CompanyName: {CompanyName} "));

            return bdr.ToString();
        }
    }
}
