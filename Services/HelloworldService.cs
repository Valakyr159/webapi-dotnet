public class HelloWorldService : IHelloWorldService
{
  public string GetHelloWorld()
  {
    return "Hello World!";
  }

}

// Creates an interface for HelloWorldService as IHelloWorldService
public interface IHelloWorldService
{
  string GetHelloWorld();
}