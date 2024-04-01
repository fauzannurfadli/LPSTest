using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ApplicationInfo
{
    public string Path { get; set; }
    public string Name { get; set; }
}
public class Application
{  
    public ApplicationInfo GetInfo()
    {
        var application = new ApplicationInfo
        {
            Path = "C:/apps/",
            Name = "Shield.exe"
        };
        return application;
    }
}

public class Laptop
{
    public string Os { get; set; } // can be modified
    public Laptop(string os)
    {
        Os = os;
    }
    public string GetOs()
    {
        return Os;
    }
}

public class Product
{
    public Product(string sku, decimal price)
    {
        SKU = sku;
        Price = price;
    }

    public string SKU { get; set; }
    public decimal Price { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Jalankan skrip
        string soal1 = Soal1();
        string soal2 = Soal2();
        string soal3 = Soal3();
        string soal4 = Soal4();
        Console.WriteLine(soal1);
        Console.WriteLine(soal2);
        Console.WriteLine(soal3);
        Console.WriteLine(soal4);
        Console.ReadLine();
    }

    static string Soal1()
    {
        // Buat variabel JSON
        dynamic application = new JObject();
        //protected diganti menjadi protectedData karena kata "protected" salah satu initial bawaan C# 
        application.protectedData = new JObject();
        application.protectedData.shieldLastRun = "shieldLastRunValue ";


        if (application != null && application.protectedData != null)
        {
            return "1) "+application.protectedData.shieldLastRun;
        }
        else
        {
            return null;
        }
    }

    static string Soal2()
    {
        Application app = new Application();
        ApplicationInfo info = app.GetInfo();
        dynamic _out = new JObject();
        _out.Path = info.Path;
        _out.Name = info.Name;

        return "2) "+JsonConvert.SerializeObject(_out);
    }

    static string Soal3()
    {
        Laptop laptop = new Laptop("macOs");
        return "3) Laptop os: " + laptop.GetOs();
    }

    static string Soal4()
    {
        var myList = new List<Product>();
        //while (true)
        //{
            for (int i = 0; i < 1000; i++)
            {
                myList.Add(new Product(Guid.NewGuid().ToString(), i));
            }
        //}
        return "4) MyList Count : "+myList.Count;
    }
}