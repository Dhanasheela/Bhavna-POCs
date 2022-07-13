using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.ServiceLayer
{
     public interface ICalculatorService
    {
        double Add(double d1, double d2);
        double Sub(double d1, double d2);
        double Mul(double d1, double d2);
        double Div(double d1, double d2);
    }
}
