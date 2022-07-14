using EmployeeApplication.Controllers;
using EmployeeApplication.Models;
using EmployeeApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EmployeeXTestProject
{
     public class EmployeeUnitTest
    {
        private EmployeeRL employeeRL;


        public EmployeeUnitTest()
        {
            if(employeeRL==null)
            {
                employeeRL = new EmployeeRL();
            }
        }
        private List<EmployeeModel> GetSampleEmployee()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>()
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
            return employees;
        }

        [Fact]
        public  void GetEmployees()
        {
            //arrange 
            var employee = GetSampleEmployee();
            employeeRL.GetEmployees();
            var controller = new EmployeeController(employeeRL);
            
            //act
            var data = controller.Get();
            var result = data ; 


            //assert
            Assert.Equal(employee.Count(), result.Count());
        }


        [Fact]
        public void GetByIDEmployees_Test_Employee()
         {
            //arrange
            var employee = GetSampleEmployee();
            var id = 2;
            employeeRL.GetId(id);
            var controller = new EmployeeController(employeeRL);


            //assertion
            var data = controller.GetID(id);
            var result = data as Object;

            //assert
            Assert.Equal(employee, result);
         }
    }

}
