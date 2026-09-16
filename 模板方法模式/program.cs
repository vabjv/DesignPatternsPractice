using System;

public abstract class BaseDecorator
{
    // 1. 模板方法：流程固定，但不做具体的性别判断
    public void Decorate()
    {
        Console.Write("开始装扮: ");
        AddShirt();       // 必须穿的
        
        if (ShouldWearBottom()) // 2. 钩子方法：子类决定是否需要下装
        {
            WearBottom();   // 3. 抽象方法：具体穿什么由子类定
        }
        
        Console.WriteLine(" 装扮完成");
    }

    protected abstract void AddShirt();
    
    // 钩子方法：默认返回 true，子类可以选择重写
    protected virtual bool ShouldWearBottom() => true; 
    
    protected abstract void WearBottom();
}

// 男士：穿衬衫 + 长裤
public class MaleDecorator : BaseDecorator
{
    protected override void AddShirt() => Console.Write("+男士衬衫");
    protected override void WearBottom() => Console.Write("+长裤");
}

// 女士：穿衬衫 + 裙子
public class FemaleDecorator : BaseDecorator
{
    protected override void AddShirt() => Console.Write("+女士衬衫");
    protected override void WearBottom() => Console.Write("+裙子");
}

// 特殊情况：比如睡衣派对，只穿衬衫不穿下装
public class PajamaDecorator : BaseDecorator
{
    protected override void AddShirt() => Console.Write("+宽松T恤");
    
    // 重写钩子：告诉模板方法，我不需要穿下装
    protected override bool ShouldWearBottom() => false;

    protected override void WearBottom() {}
}

public class Program
{
    public static void Main()
    {
        new MaleDecorator().Decorate();    // 开始装扮: +男士衬衫+长裤 装扮完成
        new FemaleDecorator().Decorate();  // 开始装扮: +女士衬衫+裙子 装扮完成
        new PajamaDecorator().Decorate();  // 开始装扮: +宽松T恤 装扮完成
    }
}