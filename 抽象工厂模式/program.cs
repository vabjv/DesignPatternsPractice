using System;

public interface IUserRepository
{
    void Insert();

    void Update();
}

public interface IOrderRepository
{
    void Insert();

    void Update();
}

public class SqlServerUserRepo : IUserRepository
{
    public void Insert() => Console.WriteLine("SqlServer插入User");

    public void Update() => Console.WriteLine("SqlServer更新User");
}

public class MySqlUserRepo : IUserRepository
{
    public void Insert() => Console.WriteLine("MySql插入User");

    public void Update() => Console.WriteLine("MySql更新User");
}

public class SqlServerOrderRepo : IOrderRepository
{
    public void Insert() => Console.WriteLine("SqlServer插入Order");

    public void Update() => Console.WriteLine("SqlServer更新Order");
}

public class MySqlOrderRepo : IOrderRepository
{
    public void Insert() => Console.WriteLine("Mysql插入Order");

    public void Update() => Console.WriteLine("Mysql更新Order");
}

public interface IFactory
{
    IUserRepository CreateUserRepo();

    IOrderRepository CreateOrderRepo();
}

public class SqlServerFactory : IFactory
{
    public IUserRepository CreateUserRepo() => new SqlServerUserRepo();

    public IOrderRepository CreateOrderRepo() => new SqlServerOrderRepo();
}

public class MySqlFactory : IFactory
{
    public IUserRepository CreateUserRepo() => new MySqlUserRepo();

    public IOrderRepository CreateOrderRepo() => new MySqlOrderRepo();
}

public class Program
{
    public static void Main()
    {
        IFactory factory = new SqlServerFactory();

        IUserRepository userRepository = factory.CreateUserRepo();
        IOrderRepository orderRepository = factory.CreateOrderRepo();
        userRepository.Insert();
        userRepository.Update();
        orderRepository.Insert();
        orderRepository.Update();

        factory = new MySqlFactory();
        IUserRepository userRepository1 = factory.CreateUserRepo();
        IOrderRepository orderRepository1 = factory.CreateOrderRepo();
        userRepository1.Insert();
        userRepository1.Update();
        orderRepository1.Insert();
        orderRepository1.Update();
    }
}