using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[Controller]")]
public class TareaController: ControllerBase
{
  protected readonly ITareasService tareasService;
  private readonly ILogger<HelloWorldController> _logger;

  public TareaController
  (
    ITareasService service,
    ILogger<HelloWorldController> logger
   )
  {
    tareasService = service;
    _logger = logger;
  }

  [HttpGet]
  public IActionResult Get()
  {
    _logger.LogDebug("Get on CategoriaService");
    return Ok(tareasService.Get());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Tarea tarea)
  {
    _logger.LogDebug("Post on CategoriaService");
    tareasService.Save(tarea);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put([FromQuery] Guid id, [FromBody] Tarea tarea)
  {
    _logger.LogDebug("Put on CategoriaService");
    tareasService.Update(id, tarea);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete([FromQuery] Guid id)
  {
    _logger.LogDebug("Delete on CategoriaService");
    tareasService.Delete(id);
    return Ok();
  }
}