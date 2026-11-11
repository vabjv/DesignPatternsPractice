using System;
using System.Collections;
using System.Collections.Generic;

public interface IIterator
{
    object First();

    object Next();
    
    object Current();

    bool IsDone();
}

public interface IAggregate
{
    IIterator CreateIterator();

    IIterator CreateIteratorDesc();
}

public class ConcretAggregate : IAggregate
{
    private readonly IList<object> _list = new List<object>();

    public int Count => _list.Count;

    public IIterator CreateIterator()
    {
        return new ConcretIterator(this);
    }

    public IIterator CreateIteratorDesc()
    {
        return new ConcretIteratorDesc(this);
    }

    public object this[int index] {
        get
        {
            return _list[index];
        }
        set
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index == Count)
            {
                _list.Add(value);
            }
            else 
            {
                _list[index] = value;
            }
        }
    }
}

public class ConcretIterator : IIterator
{
    private int index;

    private readonly ConcretAggregate _aggregate;

    public ConcretIterator(ConcretAggregate aggregate)
    {
        _aggregate = aggregate;
        index = 0;
    }

    public object First()
    {
        return _aggregate[0];
    }

    public object Next()
    {
        index++;
        if (!IsDone())
        {
            return _aggregate[index];
        }
        return null;
    }

    public object Current()
    {
        return _aggregate[index];
    }

    public bool IsDone()
    {
        return index == _aggregate.Count;
    }
}


public class ConcretIteratorDesc : IIterator
{
    private int index;

    private readonly ConcretAggregate _aggregate;

    public ConcretIteratorDesc(ConcretAggregate aggregate)
    {
        _aggregate = aggregate;
        index = aggregate.Count - 1;
    }

    public object First()
    {
        return _aggregate[_aggregate.Count - 1];
    }

    public object Next()
    {
        index--;
        if (!IsDone())
        {
            return _aggregate[index];
        }
        return null;
    }

    public object Current()
    {
        return _aggregate[index];
    }

    public bool IsDone()
    {
        return index == -1;
    }
}

public class Program
{
    public static void Main()
    {
        ConcretAggregate aggregate = new ConcretAggregate();
        for (int i = 0; i < 10; i++)
        {
            aggregate[i] = i + 1;
        }
        IIterator iterator = aggregate.CreateIterator();
        IIterator iteratorDesc = aggregate.CreateIteratorDesc();
        IList<object> iteratorList = new List<object>();
        IList<object> iteratorDescList = new List<object>();
        while (!iterator.IsDone())
        {
            iteratorList.Add(iterator.Current());
            iterator.Next();
        }
        while(!iteratorDesc.IsDone())
        {
            iteratorDescList.Add(iteratorDesc.Current());
            iteratorDesc.Next();
        }
        Console.WriteLine(string.Join(", ", iteratorList));
        Console.WriteLine(string.Join(", ", iteratorDescList));
    }
}