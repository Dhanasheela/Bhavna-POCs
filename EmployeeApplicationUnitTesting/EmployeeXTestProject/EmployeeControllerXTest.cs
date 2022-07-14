using EmployeeApplication.Controllers;
using EmployeeApplication.Models;
using EmployeeApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace EmployeeXTestProject.Moq
{
    public class EmployeeControllerXTest
    {

        Mock<IGenericRepository<EmployeeModel>> _service;

        public EmployeeControllerXTest()
        {
            _service = new Mock<IGenericRepository<EmployeeModel>>();
        }

        private List<EmployeeModel> GetSampleEmployee()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>()
            {
                new EmployeeModel
                {
                    name = "DHANU",
                    email = "dhanu@gmail.com"
                },
                new EmployeeModel
                {
                    name = "Neha",
                    email = "neha@gmail.com"
                },

            };
            return employees;
        }
        [Fact]
        public void GetEmployee_ListOfEmployee_EmployeeExistsInRepo()
        {
            //assertion
            var employee = GetSampleEmployee();
            _service.Setup(x => x.GetAll()).Returns(GetSampleEmployee);
            var controller = new EmployeeUnitTestController(_service.Object);


            //action
            var actionResult = controller.Get();
            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<EmployeeModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(GetSampleEmployee().Count(), actual.Count());
        }


        [Fact]
        public void PostEmployee_InsertOfEmployee()
        {
            //assertion  
            var employee = GetSampleEmployee();
            var newEmployee = employee[0];
            var controller = new EmployeeUnitTestController(_service.Object);

            //action
            var actionresult = controller.Post(newEmployee);
            var result = actionresult.Result;

            //assert
            Assert.IsType<OkObjectResult>(result);
            
         }
        

    }
}
