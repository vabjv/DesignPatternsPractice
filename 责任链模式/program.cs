using System;

public class Request
{
    public string Type { get; set; }
}

public abstract class Superior
{
    protected Superior MySuperior;

    public Superior(Superior superior) => MySuperior = superior;

    public abstract void Approve(Request request);
}

public class Mentor : Superior
{
    public Mentor(Superior superior) : base(superior) {}

    public override void Approve(Request request)
    {
        if (request.Type == "代码审批")
        {
            Console.WriteLine("mentor处理");
        }
        else
        {
            MySuperior.Approve(request);
        }
    }
}

public class Leader : Superior
{
    public Leader(Superior superior) : base(superior) {}

    public override void Approve(Request request)
    {
        if (request.Type == "请假")
        {
            Console.WriteLine("leader处理");
        }
        else
        {
            MySuperior.Approve(request);
        }
    }
}

public class Manager : Superior
{
    public Manager(Superior superior) : base(superior) {}

    public override void Approve(Request request)
    {
        Console.WriteLine("manager处理");
    }
}

public class Program
{
    public static void Main()
    {
        Superior manager = new Manager(null);
        Superior leader = new Leader(manager);
        Superior mentor = new Mentor(leader);
        
        Request request = new Request();
        request.Type = "代码审批";
        mentor.Approve(request);
        request.Type = "请假";
        mentor.Approve(request);
        request.Type = "加薪";
        mentor.Approve(request);
    }
}