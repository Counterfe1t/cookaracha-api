using Cookaracha.Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Cookaracha.Api.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    private readonly string _appName;

    public HomeController(IOptions<AppOptions> options)
    {
        _appName = options.Value.Name;
    }

    [HttpGet]
    public ActionResult<string> Get() => Ok(_appName);
}