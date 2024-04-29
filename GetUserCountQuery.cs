﻿using MediatR;

namespace CQRSwithMediatoR.Query
{
  public class GetUserCountQuery : IRequest<int>
  {
    public string? NameFilter { get; set; }
  }
}
