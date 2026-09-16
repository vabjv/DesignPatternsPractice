using System;

public abstract class PaymentSuper
{
    public abstract void Pay(decimal amount);
}

class AliPayment: PaymentSuper
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine("阿里支付{0}", amount);
    }
} 

class WechatPayment: PaymentSuper
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine("微信支付{0}", amount);
    }
}

public class PaymentFactory
{
    public static PaymentSuper CreatePayment(string? type)
    {
        return type?.ToLower() switch
        {
            "支付宝" => new AliPayment(),
            "微信" => new WechatPayment(),
            _ => throw new ArgumentException("不支持的支付方式")
        };
    }
}

class Program
{
    static void Main()
    {
        string? type = Console.ReadLine();
        var payment = PaymentFactory.CreatePayment(type);
        payment.Pay(122m);
    }
}