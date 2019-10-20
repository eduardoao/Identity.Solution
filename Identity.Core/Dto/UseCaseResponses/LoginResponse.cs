﻿using System.Collections.Generic;
using Identity.Api.Core.Interfaces;

namespace Identity.Api.Core.Dto.UseCaseResponses
{
  public class LoginResponse : UseCaseResponseMessage
  {
    public Token Token { get; }
    public IEnumerable<Error> Errors { get; }

    public LoginResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
    {
      Errors = errors;
    }

    public LoginResponse(Token token, bool success = false, string message = null) : base(success, message)
    {
      Token = token;
    }
  }
}
