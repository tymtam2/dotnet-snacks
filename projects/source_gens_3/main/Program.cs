using System.Text;

var x = new MyClass();
     x.SayHello2(
        
        "World"
        
        
        
        );

x.SayHello(who: "Roger");     



var b = new MyClass();

b.SayHello("ASDfds");

public class MyClass
{
    public void SayHello(string who) => Console.WriteLine($"Hello {who}!");

    public void SayHello2(string who) => Console.WriteLine($"Hello {who}!");
}
