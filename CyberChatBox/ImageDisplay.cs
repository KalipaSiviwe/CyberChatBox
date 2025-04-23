using System;
using System.Threading;

public class ImageDisplay
{
    public static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
    ____       _                        
  / ___|_   _| |__   ___  
 | |   | | | | '_ \ / _ \ 
 | |___| |_| | |_) | (_) | 
  \____|\__, |_.__/ \___/ 
        |___/                               
        ");
        Console.ResetColor();
        Thread.Sleep(500);
    }
}
