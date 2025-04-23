using System;

public class Library
{
    public static string GetResponse(string input)
    {
        switch (input)
        {
            case "how are you?":
            case "how are you":
                return "I'm secure and alert! Thanks for asking.";
            case "what's your purpose?":
            case "what is your purpose":
                return "I help users stay safe online through awareness.";
            case "what can i ask you about?":
                return "Try topics like password safety, phishing, or safe browsing.";
            case "what is password safety":
                return "Use strong, unique passwords. Avoid reusing them!";
            case "what is phishing":
                return "Be cautious of suspicious emails or links asking for credentials.";
            case "what is safe browsing":
                return "Stick to trusted websites and look for HTTPS in URLs.";
            case "help":
                return "You can ask me about Passwords, Phishing, Safe browsing or any other Cyber Security tips :)";
            default:
                return "I'm still learning. Try asking about cybersecurity tips!";
        }
    }
}
