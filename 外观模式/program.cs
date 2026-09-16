using System;

public interface IInvestment
{
    void Buy();

    void Sell();
}

public class Stock : IInvestment
{
    public void Buy()
    {
        Console.Write("购入股票");
    }

    public void Sell()
    {
        Console.Write("出售股票");
    }
}

public class NationalDebt : IInvestment
{
    public void Buy()
    {
        Console.Write("购入国债");
    }

    public void Sell()
    {
        Console.Write("出售国债");
    }
}

public class Realty : IInvestment
{
    public void Buy()
    {
        Console.Write("购入房地产");
    }

    public void Sell()
    {
        Console.Write("出售房地产");
    }
}

public class Fund
{
    private Stock _stock;

    private NationalDebt _nd;

    private Realty _realty;

    public Fund()
    {
        _stock = new Stock();
        _nd = new NationalDebt();
        _realty = new Realty();
    }

    public void Buy()
    {
        _stock.Buy();
        _nd.Buy();
        _realty.Buy();
    }

    public void Sell()
    {
        _stock.Sell();
        _nd.Sell();
        _realty.Sell();
    }
}

public class Program
{
    public static void Main()
    {
        Fund fund = new Fund();
        fund.Buy();
        fund.Sell();
    }
}