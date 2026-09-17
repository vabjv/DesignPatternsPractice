// 观察者模式（委托版）
public delegate void EventHandler(float f1, float f2);

public class WeatherSubject
{
    public event EventHandler? eventHandler;

    private float _temperature;

    private float _humidity;

    public void SetWeather(float temperature, float humidity)
    {
        _temperature = temperature;
        _humidity = humidity;
        eventHandler?.Invoke(_temperature, _humidity);
    }
}

public class TemperatureObserver
{
    public void OnTempratureChanged(float temperature, float humidity)
    {
        Console.WriteLine($"温度更新：{temperature}");
    }
}

public class HumidityObserver
{
    public void OnHumidityChanged(float temperature, float humidity)
    {
        Console.WriteLine($"湿度更新：{humidity}");
    }
}

public class Program
{
    public static void Main()
    {
        WeatherSubject weatherSubject = new WeatherSubject();
        TemperatureObserver temperatureObserver = new TemperatureObserver();
        HumidityObserver humidityObserver = new HumidityObserver();
        weatherSubject.eventHandler += temperatureObserver.OnTempratureChanged;
        weatherSubject.eventHandler += humidityObserver.OnHumidityChanged;
        weatherSubject.SetWeather(41.3f, 20.1f);
    }
}