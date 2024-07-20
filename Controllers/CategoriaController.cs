using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[Controller]")]
public class CategoriaController: ControllerBase
{
  protected readonly ICategoriaService categoriaService;
  private readonly ILogger<HelloWorldController> _logger;

  public CategoriaController
  (
    ICategoriaService service,
    ILogger<HelloWorldController> logger
   )
  {
    categoriaService = service;
    _logger = logger;
  }

  [HttpGet]
  public IActionResult Get()
  {
    _logger.LogDebug("Get on CategoriaService");
    return Ok(categoriaService.Get());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Categoria categoria)
  {
    _logger.LogDebug("Post on CategoriaService");
    categoriaService.Save(categoria);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put([FromQuery] Guid id, [FromBody] Categoria categoria)
  {
    _logger.LogDebug("Put on CategoriaService");
    categoriaService.Update(id, categoria);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete([FromQuery] Guid id)
  {
    _logger.LogDebug("Delete on CategoriaService");
    categoriaService.Delete(id);
    return Ok();
  }
}