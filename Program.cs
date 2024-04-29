using CQRSwithMediatoR.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSwithMediatoR
{
  public class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("Legend:");

        ColorConsole.WriteLineCommandHandler("Command - Handlers are blue");
        ColorConsole.WriteLineQueryHandler("Query - Handlers are yellow");
        ColorConsole.WriteLineProgram("Program code is green");
        ColorConsole.WriteLineRepository("Repository code is magenta");

        var serviceProvider = CreateServiceProvider();
        await serviceProvider.GetRequiredService<Execution>().RunAsync();

        ServiceProvider CreateServiceProvider()
        {
          var collection = new ServiceCollection();
          //This will execute our main logic.
          collection.AddScoped<Execution>();

          // This comes from the MediatR package.
          // It looks for all commands, queries and handlers and registers
          // them in the container
          //collection.AddMediatR(typeof(Program).Assembly);
          collection.AddMediatR(typeof(Program).Assembly);

          // Our repository
          collection.AddScoped<UserRepository>();

          return collection.BuildServiceProvider();
        }
    }
  }
}
