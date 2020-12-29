using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Audio;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Net;
using Pokemon.Engine;

namespace Pokemon.Scenes
{

    public class EncounterControl : UserControl
    {
        public EncounterControl()
        {
            this.DoubleBuffered = true;
        }

    }

    public class Encounter
    {
        //hudba
        Audio.Audio gameAudio = new Audio.Audio();


        private EncounterControl encounter = null;

        //tvary UI atd

        public async void Run(string enemyName, string enemyID)
        {

            //vytvoreni usercontrol
            encounter = new EncounterControl();

            //zapninani hudby
            gameAudio.EncounterAudio(1);
            Controls.ControlEnable = false;

            encounter.Width = Window.ActiveForm.Width;
            encounter.Height = Window.ActiveForm.Height;

            encounter.BackColor = Color.Transparent;
            Window.ActiveForm.Controls.Add(encounter);

            await Task.Delay(100);

            for (int i = 0; i < 10; i++)
            {
                encounter.BackColor = Color.Black;
                await Task.Delay(100);
                encounter.BackColor = Color.Transparent;
                await Task.Delay(100);
            }

            encounter.BackColor = Color.Black;

            //vytvareni eventu pro malovani do usercontrol
            encounter.Paint += new System.Windows.Forms.PaintEventHandler(Paint);

            //pridani pictureboxu
            var playerPokemon = new PictureBox();


            encounter.Controls.Add(playerPokemon);

            var enemyPokemon = new PictureBox();

            enemyPokemon.LoadAsync(@"https://img.pokemondb.net/sprites/diamond-pearl/normal/" + enemyName.ToLower() + ".png".Replace("'", ""));
            enemyPokemon.Location = new Point(530, 100);
            enemyPokemon.Size = new Size(200, 200);
            enemyPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyPokemon.BackColor = Color.Transparent;

            gameAudio.URLAudio("https://pokemoncries.com/cries-old/" + enemyID.TrimStart(new char[] { '0' }) + ".mp3");
            Console.WriteLine("https://pokemoncries.com/cries-old/" + enemyID.TrimStart(new char[] { '0' }) + ".mp3");

            encounter.Controls.Add(enemyPokemon);


        }

        private void Paint(object sender, PaintEventArgs e)
        {

            //UI

            Rectangle gradient_rectangle = new Rectangle(0, 0, encounter.Width, encounter.Height);

            Brush b = new LinearGradientBrush(gradient_rectangle, ColorTranslator.FromHtml("#003319"), ColorTranslator.FromHtml("#000000"), 65f);
      
            e.Graphics.FillRectangle(b, gradient_rectangle);

            Rectangle bar = new Rectangle(0, 500, encounter.Width, 250);

            SolidBrush c = new SolidBrush(ColorTranslator.FromHtml("#7e8f91"));
            
            e.Graphics.FillRectangle(c, bar);

            Rectangle barBorder = new Rectangle(5, 505, 720, 195);

            Pen d = new Pen(Color.Red);

            e.Graphics.DrawRectangle(d, barBorder);

        }

    }

}
