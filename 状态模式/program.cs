// 状态模式适用于有清晰的状态转换图的场景，而且这个状态转换往往是不可逆的
using System;
using System.ComponentModel;

public interface OrderState
{
    void Pay(Order order);

    void Ship(Order order);

    void Confirm(Order order);

    void Cancel(Order order);
}

// 待支付状态
public class PendingPaymentState : OrderState
{
    public void Pay(Order order)
    {
        Console.WriteLine("支付订单");
        order.ChangeState(new PaidState());
    }

    public void Ship(Order order) => Console.WriteLine("未支付，不能取消");

    public void Confirm(Order order) => Console.WriteLine("未支付，不能确认");

    public void Cancel(Order order)
    {
        Console.WriteLine("取消订单");
        order.ChangeState(new CanceledState());
    }
}

public class PaidState : OrderState
{
    public void Pay(Order order) => Console.WriteLine("已支付，不用重复支付");

    public void Ship(Order order)
    {
        Console.WriteLine("订单发货");
        order.ChangeState(new ShippedState());
    }

    public void Confirm(Order order) => Console.WriteLine("未收货，不能确认");

    public void Cancel(Order order)
    {
        Console.WriteLine("取消订单");
        order.ChangeState(new CanceledState());
    }
}

public class ShippedState : OrderState
{
    public void Pay(Order order) => Console.WriteLine("已发货，不能支付");

    public void Ship(Order order) => Console.WriteLine("已发货，不用重复发货");

    public void Confirm(Order order)
    {
        Console.WriteLine("确认收货");
        order.ChangeState(new CompletedState());
    }

    public void Cancel(Order order) => Console.WriteLine("已发货，不能取消");
}

public class CompletedState : OrderState
{
    public void Pay(Order order) => Console.WriteLine("已完成，不能支付");

    public void Ship(Order order) => Console.WriteLine("已完成，不能发货");

    public void Confirm(Order order) => Console.WriteLine("已完成，不能重复确认");

    public void Cancel(Order order) => Console.WriteLine("已完成，不能取消");
}

public class CanceledState : OrderState
{
    public void Pay(Order order) => Console.WriteLine("已取消，不能支付");

    public void Ship(Order order) => Console.WriteLine("已取消，不能发货");

    public void Confirm(Order order) => Console.WriteLine("已取消，不能确认");

    public void Cancel(Order order) => Console.WriteLine("已取消，不能重复取消");
}

public class Order
{
    private OrderState _state = new PendingPaymentState();

    public void ChangeState(OrderState state)
    {
        _state = state;
    }

    public void Pay() => _state.Pay(this);

    public void Ship() => _state.Ship(this);

    public void Confirm() => _state.Confirm(this);

    public void Cancel() => _state.Cancel(this);
}

public class Program
{
    public static void Main()
    {
        Order order = new Order();
        order.Confirm();
        order.Ship();
        order.Cancel();
        order.Pay();
        // 实际的状态模式中不能在客户端直接修改状态，状态的变化必须是订单类方法内部执行的，而不是客户端手动更改
        order.ChangeState(new PendingPaymentState());
        order.Pay();
        order.Ship();
        order.Confirm();
        order.Pay();
    }
}