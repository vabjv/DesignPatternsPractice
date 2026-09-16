using System;

public abstract class Operation
{
    public int Num1 { get; set; }

    public int Num2 { get; set; }

    public abstract double Caculator();
}

public class MulOperation : Operation
{
    public override double Caculator()
    {
        return Num1 * Num2;
    }
}

public class DivOperation : Operation
{
    public override double Caculator()
    {
        return (double)Num1 / Num2;
    }
}

public interface IFactory
{
    Operation CreateOperation();
}

public class MulFactory : IFactory
{
    public Operation CreateOperation()
    {
        return new MulOperation();
    }
}

public class DivFacroty : IFactory
{
    public Operation CreateOperation()
    {
        return new DivOperation();
    }
}

public class Program
{
    public static void Main()
    {
        string operatorType = "/";
        IFactory factory = null;
        switch (operatorType)
        {
            case "*" :
                factory = new MulFactory();
                break;

            case "/" : 
                factory = new DivFacroty();
                break;
        }
        
        Operation operation = factory.CreateOperation();
        operation.Num1 = 3;
        operation.Num2 = 4;
        Console.WriteLine(operation.Caculator());
    }
}