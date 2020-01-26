using Employee.BLL;
using Employee.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Employee.Web.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeBLL bll = new EmployeeBLL();

         // GET: api/Employee                //Using Query string
         [HttpGet]
         public IEnumerable<EmployeeBO> Get()                 //Ok
         {
             return bll.GetALLEmployee();
         }


        /* //Getting Employee base on CompanyName. Note that the companyName/Query string here are 'All', 'Bank' and 'Production'
         [HttpGet] [EnableCors("*","*","*")]
         public HttpResponseMessage GetByCompanyName(string company = "All")       //Ok
         {
             switch (company.ToLower())
             {
                 case "all":
                     return Request.CreateResponse(HttpStatusCode.OK, bll.GetALLEmployee()); 
                 case "bank":
                     return Request.CreateResponse(HttpStatusCode.OK, bll.GetALLEmployee().Where(emp => emp.CompanyName.ToLower() == "bank").ToList());
                 case "production":
                     return Request.CreateResponse(HttpStatusCode.OK, bll.GetALLEmployee().Where(emp => emp.CompanyName.ToLower() == "production").ToList());
                 default:
                     return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"Value for Company Name must be All, Bank or Production. {company} is invalid");
             }
         }*/

        // GET: api/Employee/5
        public EmployeeBO Get(int id)             //Ok
        {
            return bll.GetEmployeeById(id);
        }

        // POST: api/Employee
        public HttpResponseMessage Post([FromBody]EmployeeBO emp)         //Ok
        {
            try
            {
                bll.AddEmployeeBLL(emp);
                var message = Request.CreateResponse(HttpStatusCode.Created, emp);
                message.Headers.Location = new Uri(Request.RequestUri +"/"+ emp.Id.ToString());
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Employee/5
        public HttpResponseMessage Put([FromUri]int id, [FromBody]EmployeeBO employee)    //Ok
        {
            try
            {

                var result = bll.UpdateEmployeeBLL(employee);
                if (!result)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with Id = {id.ToString()} is not found to update");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, employee);
                }
            }catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE: api/Employee/5
        public HttpResponseMessage Delete(int id)              //Ok
        {
            try
            {
                    var result = bll.DeleteEmployeeBLL(id);
                if (!result)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Employee with Id = {id.ToString()} is not found to delecte");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
