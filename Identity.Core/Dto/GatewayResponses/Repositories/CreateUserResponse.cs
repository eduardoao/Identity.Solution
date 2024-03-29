﻿using System.Collections.Generic;

namespace Identity.Core.Dto.GatewayResponses.Repositories
{
  public sealed class CreateUserResponse : BaseGatewayResponse
  {
    public string Id { get; }
    public CreateUserResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
    {
      Id = id;
    }
  }
}
