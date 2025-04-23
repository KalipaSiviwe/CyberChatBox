using System;
using System.Threading;

public class Greetings
{
    public static string GreetUser()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine($"\nHi {name}, I'm your Cybersecurity Awareness Bot!!");
        Thread.Sleep(500);
        return name;
    }
}
