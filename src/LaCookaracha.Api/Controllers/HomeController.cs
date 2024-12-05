using Microsoft.AspNetCore.Mvc;

namespace LaCookaracha.Api.Controllers;

[ApiController]
[Route("api/home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get() => Ok("LaCookaracha.Api");
}