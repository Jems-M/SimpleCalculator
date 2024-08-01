using CalculatorTest;
using Moq;
using Xunit;

namespace CalculatorTests
{

    public class CalculatorTests
    {

        
        

        [Fact]
        public void TestAdd()
        {
            Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
            SimpleCalculator calc = new SimpleCalculator(mockDiagnostics.Object);

            var result1 = calc.Add(2, 3);
            var result2 = calc.Add(4, 6);
            var result3 = calc.Add(5, 6);

            Assert.Equal(5, result1);
            Assert.NotEqual(9, result2);
            Assert.NotEqual(10, result3);
        }

        [Fact]
        public void TestSubtract()
        {
            Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
            SimpleCalculator calc = new SimpleCalculator(mockDiagnostics.Object);

            var result = calc.Subtract(10, 3);

            Assert.Equal(7, result);
        }

        [Fact]
        public void TestMultiply()
        {
            Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
            SimpleCalculator calc = new SimpleCalculator(mockDiagnostics.Object);

            var result = calc.Multiply(5, 3);

            Assert.Equal(15, result);
        }

        [Fact]
        public void TestDivide()
        {
            Mock<IDiagnostics> mockDiagnostics = new Mock<IDiagnostics>();
            SimpleCalculator calc = new SimpleCalculator(mockDiagnostics.Object);

            var result = calc.Divide(10, 2);

            Assert.Equal(5, result);

            try
            {
                calc.Divide(10, 0);
            } catch (DivideByZeroException)
            {
                Assert.True(true);
                return;
            }
            Assert.True(false);
        }
    }
}
