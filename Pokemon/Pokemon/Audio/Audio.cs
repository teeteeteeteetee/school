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
        SoundPlayer player = new SoundPlayer();

        public void EncounterAudio(int x)
        {
            player.SoundLocation = @"Audio\encounter.wav";

            if (x == 1) { player.Play(); } else { player.Stop(); }


        }

        //https://pokemoncries.com/cries-old/1.mp3
        public async void URLAudio(string URL)
        {
            var wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = URL;
            await Task.Delay(100);
            wplayer.controls.play();
        }

    }
}
