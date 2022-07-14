using EmployeeApplication.Models;
using EmployeeApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRL _employeeRL;
        public EmployeeController(EmployeeRL employeeRL) 
        {

            _employeeRL = employeeRL;
        }

        List<EmployeeModel> employe = new List<EmployeeModel>()
       {
           new EmployeeModel()

           {
               id=1,name="dhanu",email="dhanu@gmail.com"
           },
           new EmployeeModel()
           {
               id=2,name="supriya" ,email="sup@gmail.com"
           },
            new EmployeeModel()
           {
               id=3,name="ramu" ,email="ramu@gmail.com"
           },
             new EmployeeModel()
           {
               id=4,name="Raki" ,email="rak@gmail.com"
           },
        };

       

        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {

         return _employeeRL.GetEmployees().ToList();
            
        }
        // GET: api/<EmployeeController>
       
                  // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult GetID(int id)
        {
          var obj=  _employeeRL.GetId(id);
            return Ok(obj);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult Post(EmployeeModel employee)
        {
           _employeeRL.AddEmployee(employee);
            return Ok("created successfully");
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put( EmployeeModel employe)
        {
         _employeeRL.UpdateEmployee(employe);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IEnumerable<EmployeeModel> Delete(int id)
        {
          return  _employeeRL.DeleteEmployee(id);
          
            
        }
    }
}
