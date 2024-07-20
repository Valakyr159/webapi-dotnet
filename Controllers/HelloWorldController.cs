using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  protected readonly IHelloWorldService helloWorldService;
  private readonly ILogger<HelloWorldController> _logger;

  TareasContext dbContext;

  public HelloWorldController
  (
    IHelloWorldService helloWorld,
    ILogger<HelloWorldController> logger,
    TareasContext db
   )
  {
    helloWorldService = helloWorld;
    _logger = logger;
    dbContext = db;
  }

  [HttpGet]
  public IActionResult Get()
  {
    _logger.LogDebug("Logging on HelloWorldController");
    return Ok(helloWorldService.GetHelloWorld());
  }

  [HttpGet]
  [Route("createDb")]
  public IActionResult CreateDatabase()
  {
    dbContext.Database.EnsureCreated();
    return Ok();
  }
}