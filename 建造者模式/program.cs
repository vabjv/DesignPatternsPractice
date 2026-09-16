using System;

public class Computer
{
    public string CPU { get; set; }

    public string RAM { get; set; }

    public string GPU { get; set; }
}

// 建造者和模板方法的区别在于，建造者是构建产物并返回，并没有特定的顺序
// 模板方法模式并不构建任何东西，只是按照固定的流程执行
public abstract class BuildComputer
{
    public abstract void AddCPU();

    public abstract void AddRAM();

    public abstract void AddGPU();

    public abstract Computer GetComputer();
}

public class BuildHighComputer : BuildComputer
{
    private readonly Computer _computer = new Computer();

    public override void AddCPU() => _computer.CPU = "高质量CPU";

    public override void AddRAM() => _computer.RAM = "高质量RAM";

    public override void AddGPU() => _computer.GPU = "高质量GPU";

    public override Computer GetComputer() => _computer;
}

public class BuildLowComputer : BuildComputer
{
    private readonly Computer _computer = new Computer();

    public override void AddCPU() => _computer.CPU = "低质量CPU";

    public override void AddRAM() => _computer.RAM = "低质量RAM";

    public override void AddGPU() => _computer.GPU = "低质量GPU";

    public override Computer GetComputer() => _computer;
}

public class Director
{
    private readonly BuildComputer _builder;

    public Director(BuildComputer builder) => _builder = builder;

    public Computer Build()
    {
        _builder.AddCPU();
        _builder.AddRAM();
        _builder.AddGPU();
        return _builder.GetComputer();
    }
}

public class Program
{
    public static void Main()
    {
        Director director = new Director(new BuildHighComputer());
        Computer highComputer = director.Build();
        Console.WriteLine(highComputer.CPU);
        Console.WriteLine(highComputer.RAM);
        Console.WriteLine(highComputer.GPU);
        director = new Director(new BuildLowComputer());
        Computer lowComputer = director.Build();
        Console.WriteLine(lowComputer.CPU);
        Console.WriteLine(lowComputer.RAM);
        Console.WriteLine(lowComputer.GPU);
    }
}