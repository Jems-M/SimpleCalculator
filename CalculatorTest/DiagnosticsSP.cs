using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    public class DiagnosticsSP : IDiagnostics
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public void Log(string message)
        {
            Console.WriteLine($"[Diagnostics] {message}");
        }
    }
}
