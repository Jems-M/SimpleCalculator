using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    public class NullDiagnostics : IDiagnostics
    {
        public void Log(string message)
        {
            // do nothing
        }
    }
}
