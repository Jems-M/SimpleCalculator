using Microsoft.AspNetCore.Mvc;
using CalculatorTest;
using Microsoft.Extensions.Logging.Console;

namespace CalcWeb.Controllers
{
    [Route("api/calc")]
    public class CalcController : ControllerBase
    {
        [HttpGet("{num1}/{op}/{num2}")]
        public IActionResult Calculate(int num1, int num2, string op)
        {
            int result;
            Diagnostics diag = new Diagnostics();
            SimpleCalculator calc = new SimpleCalculator(diag);
            switch (op) 
            {
                case "add":
                    result = calc.Add(num1, num2);
                    break;
                case "subtract":
                    result = calc.Subtract(num1, num2);
                    break;
                case "multiply":
                    result = calc.Multiply(num1, num2);
                    break;
                case "divide":
                    result = calc.Divide(num1, num2);
                    break;
                default:
                    return BadRequest("Invalid operator");
            }
            return Ok(result);
            
        }
    }
}
