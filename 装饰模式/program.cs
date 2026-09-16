using System;

public abstract class Decorator
{
    public abstract void Show();
}

public class XiaoMing : Decorator
{
    public override void Show()
    {
        Console.Write("XiaoMing");
    }
}

public class XiaoLi : Decorator
{
    public override void Show()
    {
        Console.Write("XiaoLi");
    }
}

public class ConcretDecorator : Decorator
{
    private readonly Decorator _decorator;

    public ConcretDecorator(Decorator decorator)
    {
        _decorator = decorator;
    }

    public override void Show()
    {
        _decorator.Show();
    }
}

public class HatDecorator : ConcretDecorator
{
    public HatDecorator(Decorator decorator)
        : base(decorator) {}

    public override void Show()
    {
        base.Show();
        Console.Write("+Hat");
    }
}

public class TshirtDecorator : ConcretDecorator
{
    public TshirtDecorator(Decorator decorator)
        : base(decorator) {}

    public override void Show()
    {
        base.Show();
        Console.Write("+Tshirt");
    }
}

public class PantsDecorator : ConcretDecorator
{
    public PantsDecorator(Decorator decorator)
        : base(decorator) {}

    public override void Show()
    {
        base.Show();
        Console.Write("+Pants");
    }
}

public class Program
{
    public static void Main()
    {
        Decorator xiaoLi = new XiaoLi();
        xiaoLi = new HatDecorator(xiaoLi);
        xiaoLi = new PantsDecorator(xiaoLi);
        xiaoLi.Show();
        Console.WriteLine();

        Decorator xiaoMing = new XiaoMing();
        xiaoMing = new TshirtDecorator(xiaoMing);
        xiaoMing = new PantsDecorator(xiaoMing);
        xiaoMing.Show();
    }
}