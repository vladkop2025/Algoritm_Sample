//Для начала следует установить библиотеку BenchmarkDotNet, используя NuGet-пакет: 
using BenchmarkDotNet.Running;
using System.Text;
using System;

class Program
{
    static void Main(string[] args)
    {
        UseString(70000);
        Console.WriteLine("Ready to switch");
        Console.ReadKey();

        UseStringBuilder(70000);
        Console.ReadKey();
    }

    static string UseString(int n)
    {
        string value = "";

        for (int i = 0; i < n; i++)
        {
            value += i.ToString();
            value += " ";
        }

        return value;
    }

    static string UseStringBuilder(int n)
    {
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            builder.Append(i.ToString());
            builder.Append(" ");
        }

        return builder.ToString();
    }
}

//При использовании string создаётся множество строк (из-за того, что класс String представляет иммутабельный объект) и
//расходуется больше памяти, но мы не так сильно замечаем это, потому что очень часто запускается GC, что можно видеть
//на графике, наведя курсор на одну из красных отметок:

//А при работе StringBuilder такого не происходит, поскольку строка не создается до вызова метода ToString.