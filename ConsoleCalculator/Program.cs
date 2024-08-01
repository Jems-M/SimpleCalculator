using Autofac;
using CalculatorTest;
using CalculatorTests;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

var builder = new ContainerBuilder();
builder.RegisterType<SimpleCalculator>().As<ISimpleCalculator>();
builder.RegisterType<NullDiagnostics>().As<IDiagnostics>();


var container = builder.Build();

CalculatorDbContext context = new CalculatorDbContext();

using (var scope = container.BeginLifetimeScope())
{
    var calc = scope.Resolve<ISimpleCalculator>();
    Console.Write("Enter a number: ");
    int first = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter a number: ");
    int second = Convert.ToInt32(Console.ReadLine());
    Console.Write("Choose an operation (+ - * /): ");
    string operation = Console.ReadLine();

    using var client = new HttpClient();
    client.BaseAddress = new Uri(@"http://localhost:16691");

    

    switch (operation)
    {
        case "+":
            operation = "add";
            break;
        case "-":
            operation = "subtract";
            break;
        case "*":
            operation = "multiply";
            break;
        case "/":
            operation = "divide";
            break;

    }


    HttpResponseMessage response = await client.GetAsync($"api/calc/{first}/{operation}/{second}");
    if (response.IsSuccessStatusCode)
    {
        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
    } else
    {
        Console.WriteLine("Error: " + response.StatusCode);
    }

    string diagMsg = $"{first}{operation}{second}";

    context.Database.ExecuteSqlRaw("EXEC DiagnosticsProcedure @Message",
        new SqlParameter("@Message", diagMsg));
}

