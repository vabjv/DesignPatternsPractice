using System;
using System.Collections.Generic;


public class Programmer
{
    private List<string> _modules = new();

    public void WriteCode(string module)
    {
        _modules.Add(module);
        Console.WriteLine($"开发模块：{module}");
    }

    public void RemoveCode(string module)
    {
        _modules.Remove(module);
        Console.WriteLine($"回滚模块：{module}");
    }
}

public class ProductManager
{
    private List<string> _designs = new();

    public void Design(string design)
    {
        _designs.Add(design);
        Console.WriteLine($"开始设计：{design}");
    }

    public void RemoveDesign(string design)
    {
        _designs.Remove(design);
        Console.WriteLine($"回滚设计：{design}");
    }
}

public abstract class BaseCommand
{
    public abstract void Execute();

    public abstract void Undo();
}

public class ProgramCommand : BaseCommand
{
    private readonly Programmer _programmer;

    private readonly string _module;

    public ProgramCommand(Programmer programmer, string module)
    {
        _programmer = programmer;
        _module = module;
    }
    public override void Execute()
    {
        _programmer.WriteCode(_module);
    }

    public override void Undo()
    {
        _programmer.RemoveCode(_module);
    }
}

public class DesignCommand : BaseCommand
{
    private readonly ProductManager _productManager;

    private readonly string _design;

    public DesignCommand(ProductManager productManager, string design)
    {
        _productManager = productManager;
        _design = design;
    }

    public override void Execute()
    {
        _productManager.Design(_design);
    }

    public override void Undo()
    {
        _productManager.RemoveDesign(_design);
    }
}

public class Leader
{
    private List<BaseCommand> _commands = new();

    private Stack<BaseCommand> _historyCommands = new();

    public void AddCommand(BaseCommand command)
    {
        _commands.Add(command);
    }

    public void RemoveCommand(BaseCommand command)
    {
        _commands.Remove(command);
    }

    public void ExecuteAll()
    {
        if (_commands.Count == 0)
        {
            return;
        }
        foreach(var command in _commands)
        {
            command.Execute();
            _historyCommands.Push(command);
        }
        _commands.Clear();
    }

    public void UndoLast()
    {
        if (_historyCommands.Count == 0)
        {
            return;
        }
        _historyCommands.Pop().Undo();
    }
}

public class Program
{
    public static void Main()
    {
        Leader leader = new Leader();
        Programmer programmer = new Programmer();
        ProductManager productManager = new ProductManager();
        leader.AddCommand(new DesignCommand(productManager, "design1"));
        leader.AddCommand(new DesignCommand(productManager, "design2"));
        leader.AddCommand(new ProgramCommand(programmer, "module1"));
        leader.AddCommand(new ProgramCommand(programmer, "module2"));
        leader.ExecuteAll();
        leader.UndoLast();
    }
}
