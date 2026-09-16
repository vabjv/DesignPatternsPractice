using System;
using System.Runtime.InteropServices;
using System.Text;

public abstract class PaymentSuper
{
    public abstract void pay(decimal amount);
}

class AliPayment: PaymentSuper
{
    public override void pay(decimal amount)
    {
        Console.WriteLine("支付宝支付: {0}", amount);
    }
}

class WechatPayment: PaymentSuper
{
    public override void pay(decimal amount)
    {
        Console.WriteLine("微信支付：{0}", amount);
    }
}

public class PaymentContext
{
    private PaymentSuper ps;

    public PaymentContext(PaymentSuper ps)
    {
        this.ps = ps;
    }

    public void excute(decimal amount)
    {
        ps.pay(amount);
    }
}

class Program
{
    static void Main()
    {
        string? type = Console.ReadLine();
        
        var context = type?.ToLower() switch
        {
            "支付宝" => new PaymentContext(new AliPayment()),
            "微信" => new PaymentContext(new WechatPayment()),
            _ => throw new ArgumentException("未知的支付类型") 
        };
        context.excute(122m);
    }
}