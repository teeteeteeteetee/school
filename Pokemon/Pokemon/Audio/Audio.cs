using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Threading;

namespace Pokemon.Audio
{
    public class Audio
    {

        public void EncounterAudio(int x)
        {
            SoundPlayer player = new SoundPlayer();
            player.Stream = Properties.Resources.encounter;

            if (x == 1) { player.Play(); } else { player.Stop(); }

        }

        public void AudioPlay(UnmanagedMemoryStream x)
        {
            SoundPlayer player = new SoundPlayer();
            player.Stream = x;
            player.Play();

        }

        //https://pokemoncries.com/cries-old/1.mp3
        public async void URLAudio(string URL)
        {
            try
            {
                var wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = URL;
                await Task.Delay(100);
                wplayer.controls.play();
            }
            catch (Exception)
            {

            }
        }

    }
}
