using System;

public interface ICommunication
{
    void Say();
}

public class English : ICommunication
{
    private readonly string _name;

    public English(string name)
    {
        _name = name;
    }

    public void Say()
    {
        Console.WriteLine(_name);
    }
}

public class Chinese
{
    private readonly string _name;

    public Chinese(string name)
    {
        _name = name;
    }

    public void 说话()
    {
        Console.WriteLine(_name);
    }
}

public class Translator : ICommunication
{
    private readonly Chinese _chinese;

    public Translator(string name)
    {
        _chinese = new Chinese(name);
    }

    public void Say()
    {
        _chinese.说话();
    }
}

public class Program
{
    public static void Main()
    {
        ICommunication english = new English("John");
        english.Say();
        ICommunication translator = new Translator("小明");
        translator.Say();
    }
}