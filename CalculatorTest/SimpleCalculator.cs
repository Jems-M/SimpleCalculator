using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly IDiagnostics _diagnostics;

        public SimpleCalculator(IDiagnostics diagnostics)
        {
            _diagnostics = diagnostics;
        }


        public int Add(int start, int amount)
        {
            _diagnostics.Log($"Adding {amount} to {start}");
            return start + amount;
        }

        public int Subtract(int start, int amount)
        {
            _diagnostics.Log($"Subtracting {amount} from {start}");
            return start - amount;
        }

        public int Multiply(int start, int amount)
        {
            _diagnostics.Log($"Multiplying {start} by {amount}");
            return start * amount;
        }

        public int Divide(int start, int amount)
        {
            _diagnostics.Log($"Dividing {start} by {amount}");
            return start / amount;
        }
    }
}
