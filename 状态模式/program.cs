using System;

public abstract class State
{
    public abstract void Charge(Passenger p);
}

public class ChildrenState : State
{
    public override void Charge(Passenger p)
    {
        if (p.Age < 18)
        {
            Console.WriteLine("未成年，不收费");
        }
        else
        {
            // 状态模式中，状态一定要变化
            p.ChangeState(new HealthyAdultState());
            p.Charge();
        }
    }
}

public class HealthyAdultState : State
{
    public override void Charge(Passenger p)
    {
        if (!p.IsDisabled)
        {
            Console.WriteLine("成年人，收费");
        }
        else
        {
            p.ChangeState(new DisabledAdultState());
            p.Charge();
        }
    }
}

public class DisabledAdultState : State
{
    public override void Charge(Passenger p)
    {
        Console.WriteLine("残疾人，不收费");
    }
}

public class Passenger
{
    public int Age { get; set; }

    public bool IsDisabled { get; set; } = false;

    private State state = new ChildrenState();

    public void ChangeState(State state)
    {
        this.state = state;
    }

    public void Charge()
    {
        state.Charge(this);
    }
}

public class Program
{
    public static void Main()
    {
        Passenger passenger = new Passenger();
        passenger.Age = 12;
        passenger.Charge();
        passenger.Age = 24;
        passenger.Charge();
        passenger.IsDisabled = true;
        passenger.Charge();
    }
}