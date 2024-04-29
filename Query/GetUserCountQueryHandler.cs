using CQRSwithMediatoR.Infrastructure;
using MediatR;

namespace CQRSwithMediatoR.Query
{
  public class GetUserCountQueryHandler : IRequestHandler<GetUserCountQuery, int>
  {
    private readonly UserRepository _userRepository;

    public GetUserCountQueryHandler()
    {
        _userRepository = new UserRepository();
    }

    public Task<int> Handle(GetUserCountQuery request, CancellationToken cancellationToken)
    {
      ColorConsole.WriteLineQueryHandler($"Getting count of users with name '{request.NameFilter}'");
      var count = _userRepository.GetUserCount(request.NameFilter);
      ColorConsole.WriteLineQueryHandler($"Got count from repository and returning it back.");
      return Task.FromResult(count);
    }
  }
}
