using System;
using System.Media;

namespace CyberChatBox
{
    public class AudioPlayer
    {
        public void PlayGreeting(string filepath)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(filepath))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to play audio." + ex.Message);
            }
        }

    }
}
