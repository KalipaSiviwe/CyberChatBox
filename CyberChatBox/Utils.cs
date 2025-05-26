using System;

public class Utils
{
    public static string GetInput()
    {
        Console.Write("\nAsk me something (or type 'exit'): ");
        return Console.ReadLine()?.ToLower();
    }

    public static void PrintResponse(string response)
    {
        Console.WriteLine(response);
    }

    public static void PrintBotResponse(string response)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(response);
        Console.ResetColor();
    }
}
