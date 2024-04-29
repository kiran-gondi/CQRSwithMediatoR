using CQRSwithMediatoR.Infrastructure;
using MediatR;

namespace CQRSwithMediatoR.Command
{
  public class DeleteAllUsersCommandHandler : IRequestHandler<DeleteAllUsersCommand, Unit>
  {
    private readonly UserRepository _userRepository;
    public DeleteAllUsersCommandHandler()
    {
        _userRepository = new UserRepository();
    }

    public Task<Unit> Handle(DeleteAllUsersCommand request, CancellationToken cancellationToken)
    {
      ColorConsole.WriteLineCommandHandler($"Deleting all users");
      _userRepository.DeleteAll();
      ColorConsole.WriteLineCommandHandler($"All users deleted");
      return Task.FromResult(Unit.Value);
    }
  }
}
