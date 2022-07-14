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
    public class EmployeeUnitTestController : ControllerBase
    {
        private IGenericRepository<EmployeeModel> _repo ;

        public EmployeeUnitTestController(IGenericRepository<EmployeeModel> repo)
        {
            _repo = repo;
        }
        // GET: api/<EmployeeUnitTestController>

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeModel>> Get()
        {
          var result=  _repo.GetAll().ToList();

           return Ok(result);
        }

        // GET api/<EmployeeUnitTestController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<EmployeeModel>> GetBy(int id)
        {
            EmployeeModel model = _repo.GetById(id);
            if(model==null)
            {
                return NotFound("not found");
            }
            return Ok(model);
        }

        // POST api/<EmployeeUnitTestController>
        [HttpPost]
        public ActionResult<IEnumerable<EmployeeModel>> Post(EmployeeModel model)
        {
            if(model==null)
            {
                return NotFound("failed to insert");
            }
           _repo.Insert(model);

            return Ok("Inserted succesfull");
        }

        // PUT api/<EmployeeUnitTestController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<EmployeeModel>> Put(EmployeeModel model)
        {
            if(model==null)
            {
                return NotFound("not found");
            }
            _repo.Update(model);
            return NoContent();
        }

        // DELETE api/<EmployeeUnitTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
