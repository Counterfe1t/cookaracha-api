using Microsoft.AspNetCore.Mvc;

namespace LaCookaracha.Api.Controllers;

[ApiController]
[Route("api/home")]
public class HomeController
{
    [HttpGet]
    public ActionResult<string> Get() => "LaCookaracha.Api";
}