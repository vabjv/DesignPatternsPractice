using System;

public interface ISubject
{
    void Send(string message);
}

public class RealSubject : ISubject
{
    public void Send(string message)
    {
        Console.WriteLine(message);
    }
}

public class Proxy : ISubject
{
    private readonly ISubject _realSubject;

    private readonly string _userRole;

    public Proxy(ISubject realSubject, string userRole)
    {
        _realSubject = realSubject;
        _userRole = userRole;
    }

    public void Send(string message)
    {
        if (_userRole != "Admin")
        {
            Console.WriteLine("没有权限");
            return ;
        }

        _realSubject.Send(message);
    }
}

public class Program
{
    public static void Main()
    {
        var realSubject = new RealSubject();
        var proxy1 = new Proxy(realSubject, "User");
        var proxy2 = new Proxy(realSubject, "Admin");
        var message = "信息";
        proxy1.Send(message);
        proxy2.Send(message);
    }
}