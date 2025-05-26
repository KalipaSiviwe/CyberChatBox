using System;
using System.Collections.Generic;

public class Library
{
    private static readonly Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
    {
        { "password", new List<string> {
            "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.",
            "Consider using a password manager to keep your passwords safe and unique.",
            "Change your passwords regularly and never share them with anyone." } },
        { "scam", new List<string> {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
            "Never click on suspicious links or download attachments from unknown sources.",
            "If something sounds too good to be true, it probably is. Stay alert for scams." } },
        { "privacy", new List<string> {
            "Review the privacy settings on your accounts regularly.",
            "Be mindful of the personal information you share online.",
            "Use two-factor authentication to enhance your privacy and security." } },
        { "safe browsing", new List<string> {
            "Stick to trusted websites and look for HTTPS in URLs.",
            "Avoid clicking on pop-ups or suspicious ads while browsing.",
            "Keep your browser and plugins up to date to protect against vulnerabilities."
        } },
        { "password safety", new List<string> {
            "Use strong, unique passwords for each account and avoid reusing them!",
            "Enable two-factor authentication wherever possible for added security.",
            "Never share your passwords and avoid writing them down where others can find them."
        } },
        { "phishing", new List<string> {
            "Be cautious of suspicious emails or links asking for credentials.",
            "Phishing attempts often create a sense of urgency. Take your time before responding.",
            "Check URLs carefully before entering your login details and never provide sensitive information via email."
        } }
    };

    private static readonly List<string> defaultResponses = new List<string>
    {
        "I'm still learning. Try asking about cybersecurity tips!",
        "Sorry, I didn't quite get that. Can you rephrase your question?",
        "I'm not sure I understand. Could you ask about something related to cybersecurity?"
    };

    private static readonly Dictionary<string, string> sentimentResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "worried", "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe." },
        { "curious", "Curiosity is great! Learning about cybersecurity helps you stay protected." },
        { "frustrated", "I know cybersecurity can be overwhelming. I'm here to help you step by step." }
    };

    public static string GetResponse(string input, ChatBotData userData)
    {
        // Sentiment detection (simple keyword-based)
        foreach (var sentiment in sentimentResponses.Keys)
        {
            if (input.Contains(sentiment, StringComparison.OrdinalIgnoreCase))
            {
                userData.LastSentiment = sentiment;
                return sentimentResponses[sentiment];
            }
        }

        // Keyword recognition and memory/recall
        foreach (var keyword in keywordResponses.Keys)
        {
            if (input.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                // Store favorite topic if user expresses interest
                if (input.Contains("interested") || input.Contains("like") || input.Contains("favourite") || input.Contains("favorite"))
                {
                    userData.FavoriteTopic = keyword;
                    return $"Great! I'll remember that you're interested in {keyword}. It's a crucial part of staying safe online.";
                }
                // Random response for the keyword
                var responses = keywordResponses[keyword];
                var rand = new Random();
                return responses[rand.Next(responses.Count)];
            }
        }

        // Recall favorite topic in later conversation
        if (!string.IsNullOrEmpty(userData.FavoriteTopic) && input.Contains("privacy", StringComparison.OrdinalIgnoreCase))
        {
            return $"As someone interested in {userData.FavoriteTopic}, you might want to review the security settings on your accounts.";
        }

        // Handle greetings and general questions
        if (input.Contains("how are you"))
            return "I'm secure and alert! Thanks for asking.";
        if (input.Contains("purpose"))
            return "I help users stay safe online through awareness.";
        if (input.Contains("what can i ask"))
            return "Try topics like password safety, phishing, or safe browsing.";
        if (input.Contains("help"))
            return "You can ask me about Passwords, Phishing, Safe browsing or any other Cyber Security tips :)";

        // Error handling: default response for unknown input
        var random = new Random();
        return defaultResponses[random.Next(defaultResponses.Count)];
    }
}
