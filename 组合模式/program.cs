using System;
using System.Collections.Generic;

public abstract class Company
{
    protected string Name;

    public Company(string name) => Name = name;

    public abstract void Add(Company company);

    public abstract void Remove(Company company);

    public abstract void Display(int depth);

    public abstract void Duty();
}

public class ConcreteCompany : Company
{
    private readonly List<Company> _children = new List<Company>();

    public ConcreteCompany(string name) : base(name) {}

    public override void Add(Company company) => _children.Add(company);

    public override void Remove(Company company) => _children.Remove(company);

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + Name);
        
        foreach(var company in _children)
        {
            company.Display(depth + 2);
        }
    }

    public override void Duty()
    {
        foreach(var company in _children)
        {
            company.Duty();
        }
    }
}

public class HRDepart : Company
{
    public HRDepart(string name) : base(name) {}

    public override void Add(Company company) {}

    public override void Remove(Company company) {}

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + Name);
    }

    public override void Duty()
    {
        Console.WriteLine("负责人事");
    }
}

public class MessageDepart : Company
{
    public MessageDepart(string name) : base(name) {}

    public override void Add(Company company) {}

    public override void Remove(Company company) {}

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + Name);
    }

    public override void Duty()
    {
        Console.WriteLine("负责信息");
    }
}

public class Program
{
    public static void Main()
    {
        Company root = new ConcreteCompany("总公司");
        root.Add(new HRDepart("总公司人力"));
        root.Add(new MessageDepart("总公司信息"));

        Company shangHai = new ConcreteCompany("上海分公司");
        shangHai.Add(new HRDepart("上海分公司人力"));
        root.Add(shangHai);

        root.Display(0);
        root.Duty();
    }
}