using webapi.Models;
namespace webapi.Services;

public class TareaService : ITareasService
{
  TareasContext context;
  public TareaService(TareasContext dbcontext)
  {
    context = dbcontext;
  }
  public IEnumerable<Tarea> Get()
  {
    return context.Tareas;
  }

  public async Task Save(Tarea tareas)
  {
    context.Add(tareas);
    await context.SaveChangesAsync();
  }

  public async Task Update(Guid id, Tarea tarea)
  {
    var tareaActual = context.Tareas.Find(id);
    if(tareaActual != null)
    {
      tareaActual.Titulo = tarea.Titulo;
      tareaActual.CategoriaId = tarea.CategoriaId;
      tareaActual.Descripcion = tarea.Descripcion;
      tareaActual.PrioridadTarea = tarea.PrioridadTarea;
      tareaActual.FechaCreacion = tarea.FechaCreacion;
      tareaActual.Resumen = tarea.Resumen;

      await context.SaveChangesAsync();
  }
}

  public async Task Delete(Guid id)
  {
    var tareaActual = context.Tareas.Find(id);
    if(tareaActual != null)
    {
      context.Remove(tareaActual);
      await context.SaveChangesAsync();
    }
  }
}


public interface ITareasService
{
  IEnumerable<Tarea> Get();
  Task Save(Tarea tarea);
  Task Update(Guid id, Tarea tarea);
  Task Delete(Guid id);
}