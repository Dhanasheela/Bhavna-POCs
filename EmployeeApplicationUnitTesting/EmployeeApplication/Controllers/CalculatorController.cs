using EmployeeApplication.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CalculatorController : ControllerBase
    {

        private ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
            {
            _calculatorService = calculatorService;
            }


        [HttpPost]
        [Route("Add")]
       public double  Add(double d1,double d2)
        {
            return _calculatorService.Add(d1, d2);
        }

        [HttpPost]
        [Route("Sub")]
        public double Sub(double d1, double d2)
        {
            return _calculatorService.Sub(d1, d2);
        }

        [HttpPost]
        [Route("Mul")]
        public double Mul(double d1, double d2)
        {
            return _calculatorService.Mul(d1, d2);
        }

        [HttpPost]
        [Route("Div")]
        public double Div(double d1, double d2)
        {
            return _calculatorService.Div(d1, d2);
        }

    }
}
