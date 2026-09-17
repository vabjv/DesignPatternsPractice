public interface IObserver
{
    void Update(float temperature, float humidity);
}

public interface ISubject
{
    void Attach(IObserver observer);

    void Detach(IObserver observer);

    void Notify();
}

public class WeatherSubject : ISubject
{
    // 不传参的情况下，声明时直接初始化，相较于在构造函数中初始化更好
    // 引用类型初始化时，最好声明为readonly
    private readonly List<IObserver> _observers = new List<IObserver>();

    private float _temperature;

    private float _humidity;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver o in _observers)
        {
            o.Update(_temperature, _humidity);
        }
    }

    public void SetWeather(float temperature, float humidity)
    {
        _temperature = temperature;
        _humidity = humidity;
        Notify();
    }
}

public class TemperatureObserver : IObserver
{
    public void Update(float temperature, float humidity)
    {
        Console.WriteLine($"温度更新：{temperature}");
    }
}

public class HumidityObserver : IObserver
{
    public void Update(float temperature, float humidity)
    {
        Console.WriteLine($"湿度更新: {humidity}");
    }
}

public class Program
{
    public static void Main()
    {
        WeatherSubject weatherSubject = new WeatherSubject();
        TemperatureObserver temperatureObserver = new TemperatureObserver();
        HumidityObserver humidityObserver = new HumidityObserver();
        weatherSubject.Attach(temperatureObserver);
        weatherSubject.Attach(humidityObserver);
        weatherSubject.SetWeather(37.6f, 19.0f);
        weatherSubject.Detach(humidityObserver);
        weatherSubject.SetWeather(37.8f, 19.5f);
    }
}