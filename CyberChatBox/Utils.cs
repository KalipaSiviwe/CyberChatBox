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
}
