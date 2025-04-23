using System;

using CyberChatBox;

class Program
{
    static void Main()
    {
        AudioPlayer audioplayer = new AudioPlayer();
        audioplayer.PlayGreeting("AudioFile/Greeting.wav");
        
        ImageDisplay.DisplayAsciiArt();
        var userName = Greetings.GreetUser();  

        ChatBotData userData = new ChatBotData { UserName = userName };

        RunBot();
    }

    static void RunBot()
    {
        string input;
        while (true)
        {
            input = Utils.GetInput();

            if (string.IsNullOrWhiteSpace(input))
            {
                Utils.PrintResponse("I didn't catch that. Could you rephrase?");
                continue;
            }

            if (input == "exit") break;

            string response = Library.GetResponse(input);
            Utils.PrintResponse(response);
        }

        MenuDisplay.ShowExitMessage();
    }
}
