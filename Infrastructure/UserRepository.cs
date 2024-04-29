using CQRSwithMediatoR.Domain;

namespace CQRSwithMediatoR.Infrastructure
{
  public class UserRepository
  {
    private readonly List<User> _users = new List<User>();
    
    public User AddUser(User user)
    {
      ColorConsole.WriteLineRepository($"Adding user with name.'{user.Name}'");
      var currentMaxId = !_users.Any() ? 0 : _users.Max(u => u.Id);
      user.Id = currentMaxId + 1;
      _users.Add(user);
      return user;
    }

    public int GetUserCount(string? name)
    {
      ColorConsole.WriteLineRepository($"Filtering users where name is '{name}'");
      return _users == null ? _users.Count : _users.Count(u => u.Name.Contains(name));
    }

    public void DeleteAll()
    {
      ColorConsole.WriteLineRepository($"Deleting all users.");
      _users.Clear();
    }
  }
}
