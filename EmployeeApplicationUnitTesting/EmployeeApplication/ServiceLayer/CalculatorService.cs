using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApplication.ServiceLayer
{
    public class CalculatorService : ICalculatorService
    {
        public double Add(double d1, double d2)
        {
            return (d1 + d2);
        }

        public double Div(double d1, double d2)
        {
            if(d2==0)
            {
                throw new DivideByZeroException("x2 cannot be zero");
            }
            return (d1 / d2);
        }

        public double Mul(double d1, double d2)
        {
            return (d1 * d2);
        }

        public double Sub(double d1, double d2)
        {
            return (d1 - d2);
        }
    }
}
