using System;

public abstract class BaseSoftware
{
    public abstract void Show();
}

public abstract class BaseHardware
{
    public abstract void Show();
}

public class MemoSoftware : BaseSoftware
{
    public override void Show()
    {
        Console.WriteLine("软件：备忘录");
    }
}

public class ClockSoftware : BaseSoftware
{
    public override void Show()
    {
        Console.WriteLine("软件：时钟");
    }
}

public class BatteryHardware : BaseHardware
{
    public override void Show()
    {
        Console.WriteLine("硬件：电池");
    }
}

public class ChipHardware : BaseHardware
{
    public override void Show()
    {
        Console.WriteLine("硬件：芯片");
    }
}

public abstract class BaseTelephone
{
    protected readonly BaseSoftware Software;

    protected readonly BaseHardware Hardware;

    public BaseTelephone(BaseSoftware software, BaseHardware hardware)
    {
        Software = software;
        Hardware = hardware;
    }

    public abstract void Show();
}

public class AppleTelephone : BaseTelephone
{
    public AppleTelephone(BaseSoftware software, BaseHardware hardware)
        : base(software, hardware) {}

    public override void Show()
    {
        Console.WriteLine("苹果手机");
        Software.Show();
        Hardware.Show();
    }
}

public class Program
{
    public static void Main()
    {
        BaseTelephone telephone = new AppleTelephone(
            new ClockSoftware(),
            new ChipHardware()
        );
        telephone.Show();
    }
}