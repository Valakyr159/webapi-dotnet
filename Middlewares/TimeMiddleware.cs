public class TimeMiddleware
{
  readonly RequestDelegate next;

  public TimeMiddleware(RequestDelegate nextRequest)
  {
    next = nextRequest;
  }

  public async Task Invoke(HttpContext context)
  {  

    // Executes next middleware
    await next(context);

    // This Middleware Logic
    if(context.Request.Query.Any(p=> p.Key == "time"))
    {
      await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
    }

  }


}
public static class TimeMiddlewareExtension
{
  // Injects Middleware in builder
  public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<TimeMiddleware>();
  }
}