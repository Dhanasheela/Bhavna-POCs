using EmployeeApplication.ServiceLayer;
using System;
using Xunit;

namespace EmployeeXTestProject
{
    public class CalculatorControllerTest
    {
        private ICalculatorService _unitTesting = null;
            
        
        public CalculatorControllerTest()
        {

            if(_unitTesting==null)
            {
                _unitTesting = new CalculatorService();
            }

        }

        [Fact]
        public void  Add()
        {
            //arrange
            double a = 5;
            double b = 3;
            double expected = 8;


            //act
            var actual = _unitTesting.Add(a, b);

            //Assert
            Assert.Equal(expected, actual, 0);

        }
        [Fact]
        public void Sub()
        {
            //arrange
            double a = 5;
            double b = 3;
            double expected = 2;

            //act
            var actual = _unitTesting.Sub(a, b);

            //Assert
            Assert.Equal(expected, actual, 0);
        }

        ////public void Mul()
        ////{

        ////}
    }
}
