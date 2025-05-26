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

        RunBot(userData);
    }

    static void RunBot(ChatBotData userData)
    {
        string input;
        string lastResponse = null;
        while (true)
        {
            input = Utils.GetInput();

            if (string.IsNullOrWhiteSpace(input))
            {
                Utils.PrintResponse("I didn't catch that. Could you rephrase?");
                continue;
            }

            if (input == "exit") break;

            string response = Library.GetResponse(input, userData);
            Utils.PrintBotResponse(response);
            lastResponse = response;
        }

        MenuDisplay.ShowExitMessage();
    }
}
