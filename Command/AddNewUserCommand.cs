using CQRSwithMediatoR.Domain;
using MediatR;

namespace CQRSwithMediatoR.Command
{
  public class AddNewUserCommand : IRequest<User>
  {
      public string Name { get; set; }
  }
}
