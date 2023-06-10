using Utilities.Aspect.Concrete;

var title = "example";
breath(title);

[LoggingAspect]
void breath(string title)
{
    Console.WriteLine(title);
}