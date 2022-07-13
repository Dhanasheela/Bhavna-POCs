using EmployeeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeApplication.Repository
{
    public class EmployeeRL
    {
        List<EmployeeModel> emp = new List<EmployeeModel>()
            {
            new EmployeeModel()
            {
                id = 1, name = "dhanu", email = "dhanu@gmail.com"
            },
            new EmployeeModel()
            {
                id=2,name="supriya" ,email="sup@gmail.com"
            },

            };
        public List<EmployeeModel> GetEmployees()
        {
            return emp;
        }
        public object  GetId(int id)
        {

          var result =emp.Find(employee=>employee.id==id);
            return result;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            
           emp.Add(employee);
         
          
        }
        public IEnumerable<EmployeeModel> DeleteEmployee(int id)
        {

          
            var result= emp.Find(e=>e.id==id);
            if(result!=null)
            {
               emp.Remove(result);
               //  emp.Save();
             }
           return  emp;
        }
        public bool UpdateEmployee(EmployeeModel employee)
        {
            var result = emp.Where(s => s.id == employee.id).FirstOrDefault<EmployeeModel>();
            if(result!=null)
            {
                result.name = employee.name;
                result.email = employee.email;
                
                return true;
            }
            
           return false;
           
        }

    }
}
