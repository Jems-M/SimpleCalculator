namespace CalculatorTest
{
    public interface ISimpleCalculator
    {
        int Add(int start, int amount);
        int Subtract(int start, int amount);
        int Multiply(int start, int by);
        int Divide(int start, int by);
    }


    public interface IDiagnostics
    {
        void Log(string message);
    }


    public class CalculatorApi
    {
        
    }
}
