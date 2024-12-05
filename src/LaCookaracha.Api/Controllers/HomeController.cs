using Microsoft.AspNetCore.Mvc;

namespace LaCookaracha.Api.Controllers;

[ApiController]
[Route("home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get() => Ok("LaCookaracha.Api");
}