using System;
using System.Collections.Generic;

public abstract class Colleague
{
    protected Mediator ConcreteMediator;

    public Colleague(Mediator mediator) => ConcreteMediator = mediator;

    public abstract void SendMessage(string message);

    public abstract void ReceiveMessage(string message);
}

public class ConcreteColleague1 : Colleague
{
    private readonly string _name = "同事1";

    public ConcreteColleague1(Mediator mediator) : base(mediator) {}

    public override void SendMessage(string message)
    {
        ConcreteMediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{_name}收到消息{message}");
    }
}

public class ConcreteColleague2 : Colleague
{
    private readonly string _name = "同事2";

    public ConcreteColleague2(Mediator mediator) : base(mediator) {}

    public override void SendMessage(string message)
    {
        ConcreteMediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{_name}收到消息{message}");
    }
}

public class ConcreteColleague3 : Colleague
{
    private readonly string _name = "同事3";

    public ConcreteColleague3(Mediator mediator) : base(mediator) {}

    public override void SendMessage(string message)
    {
        ConcreteMediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"{_name}收到消息{message}");
    }
}

public abstract class Mediator
{
    protected readonly List<Colleague> Colleagues = new();

    public void AddColleague(Colleague colleague) => Colleagues.Add(colleague);

    public void RemoveColleague(Colleague colleague) => Colleagues.Remove(colleague);

    public abstract void SendMessage(string message, Colleague colleague);
}

public class ConcreteMediator : Mediator
{
    public override void SendMessage(string message, Colleague colleague)
    {
        foreach(Colleague currentColleague in Colleagues)
        {
            if (currentColleague != colleague)
            {
                currentColleague.ReceiveMessage(message);
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        ConcreteMediator concreteMediator = new ConcreteMediator();
        ConcreteColleague1 concreteColleague1 = new ConcreteColleague1(concreteMediator);
        ConcreteColleague2 concreteColleague2 = new ConcreteColleague2(concreteMediator);
        ConcreteColleague3 concreteColleague3 = new ConcreteColleague3(concreteMediator);
        concreteMediator.AddColleague(concreteColleague1);
        concreteMediator.AddColleague(concreteColleague2);
        concreteMediator.AddColleague(concreteColleague3);
        concreteColleague1.SendMessage("消息1");
        concreteColleague2.SendMessage("消息2");
        concreteColleague3.SendMessage("消息3");
    }
}