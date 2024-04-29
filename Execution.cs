using CQRSwithMediatoR.Command;
using CQRSwithMediatoR.Query;
using MediatR;

namespace CQRSwithMediatoR
{
  public class Execution
  {
    private readonly IMediator _mediator;
    public Execution(IMediator mediator)
    {
      _mediator = mediator;
    }

    public async Task RunAsync()
    {
      ColorConsole.WriteLineProgram("Creating a new user with name 'Steven'");
      var user0 = await _mediator.Send(new AddNewUserCommand { Name = "Steven" });
      ColorConsole.WriteLineProgram($"User has id: {user0.Id}");

      Console.WriteLine();

      ColorConsole.WriteLineProgram("Creating a new user with name 'Rebecca'");
      var user1 = await _mediator.Send(new AddNewUserCommand { Name = "Rebecca" });
      ColorConsole.WriteLineProgram($"User has id: {user1.Id}");

      Console.WriteLine();

      ColorConsole.WriteLineProgram($"Get count of users with name 'Rebecca'");
      var count = await _mediator.Send(new GetUserCountQuery { NameFilter = "Rebecca" });
      ColorConsole.WriteLineProgram($"Found {count} entries");

      Console.WriteLine();
      ColorConsole.WriteLineProgram($"Deleting all users");
      await _mediator.Send(new DeleteAllUsersCommand());
      ColorConsole.WriteLineProgram($"All users deleted");
      
      Console.ReadLine();

    }
  }
}
