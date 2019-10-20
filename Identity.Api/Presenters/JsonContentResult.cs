using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Presenters
{
  public sealed class JsonContentResult : ContentResult
  {
    public JsonContentResult()
    {
      ContentType = "application/json";
    }
  }
}
