using System;

// 调用时创建实例
// public class Singleton
// {
//     private static Singleton _instance;

//     private static readonly object synclock = new object();

//     private Singleton() {}

//     public static Singleton GetInstance()
//     {
//         if (_instance == null)
//         {
//             lock(synclock)
//             {
//                 if (_instance == null)
//                 {
//                     _instance = new Singleton();
//                 }
//             }
//         }

//         return _instance;
//     }
// }

// 声明时创建实例
public sealed class Singleton
{
    private static readonly Singleton _instance = new Singleton();

    private Singleton() {}

    public static Singleton GetInstance()
    {
        return _instance;
    }
}

public class Program
{
    public static void Main()
    {
        var instance1 = Singleton.GetInstance();
        var instance2 = Singleton.GetInstance();
        Console.WriteLine(instance1 == instance2);
    }
}

