using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Net;
using System.Diagnostics;

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
        string _enemyName;

        //tlacitka
        Button attackPokemon = new Button();
        Button catchPokemon = new Button();
        Button runPokemon = new Button();
        Button changePokemon = new Button();

        //random generator
        Random rnd = new Random();

        //hudba
        Audio.Audio gameAudio = new Audio.Audio();

        private EncounterControl encounter = null;

        Label label = new Label();

        //tvary UI atd

        public async void Run(string enemyName, string enemyID)
        {
            _enemyName = enemyName;
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

            var pkmnPlayer = new Object.Player();
            var pkmn = new Object.Pokemon();

            playerPokemon.LoadAsync(@"https://img.pokemondb.net/sprites/diamond-pearl/normal/" + pkmn.getPokemonNameByID(pkmnPlayer.getMainPokemon() - 1).ToLower() + ".png".Replace("'", "").Replace("♂", "-m").Replace("♀", "-f"));
            playerPokemon.Location = new Point(50, 260);
            playerPokemon.Size = new Size(250, 250);
            playerPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
            playerPokemon.BackColor = Color.Transparent;

            gameAudio.URLAudio($"https://pokemoncries.com/cries-old/{pkmnPlayer.getMainPokemon()}.mp3");
            Console.WriteLine($"https://pokemoncries.com/cries-old/{pkmnPlayer.getMainPokemon()}.mp3");

            encounter.Controls.Add(playerPokemon);

            await Task.Delay(1500);

            var enemyPokemon = new PictureBox();

            enemyPokemon.LoadAsync(@"https://img.pokemondb.net/sprites/diamond-pearl/normal/" + enemyName.ToLower() + ".png".Replace("'", "").Replace("♂", "-m").Replace("♀", "-f").Replace(". ", "-"));
            enemyPokemon.Location = new Point(530, 100);
            enemyPokemon.Size = new Size(200, 200);
            enemyPokemon.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyPokemon.BackColor = Color.Transparent;

            gameAudio.URLAudio("https://pokemoncries.com/cries-old/" + enemyID.TrimStart(new char[] { '0' }) + ".mp3");
            Console.WriteLine("https://pokemoncries.com/cries-old/" + enemyID.TrimStart(new char[] { '0' }) + ".mp3");

            encounter.Controls.Add(enemyPokemon);

            label.Show();
            label.Text = $"WOOOOOOOOW on na vas zautocil >:( {enemyName} :DDDDDD =D";
            label.Location = new Point(100, 500);
            label.Size = new Size(500, 200);
            label.BackColor = Color.Transparent;
            label.ForeColor = Color.White;
            label.Font = new Font("Arial", 24, FontStyle.Bold);
            label.TextAlign = ContentAlignment.MiddleCenter;

            encounter.Controls.Add(label);

            await Task.Delay(2000);

            label.Hide();

            //utikani pred pokemonem [BUTTON]
            runPokemon.Show();
            runPokemon.Location = new Point(240, 650);
            runPokemon.Size = new Size(100, 50);
            runPokemon.MouseClick += new MouseEventHandler(runPokemon_Click);
            runPokemon.BackColor = Color.LightBlue;
            runPokemon.ForeColor = Color.Black;
            runPokemon.Font = new Font("Arial", 15, FontStyle.Bold);
            runPokemon.Text = "Utect";

            encounter.Controls.Add(runPokemon);

            //vymenit pokemona [BUTTON]
            changePokemon.Show();
            changePokemon.Location = new Point(360, 650);
            changePokemon.Size = new Size(100, 50);
            changePokemon.MouseClick += new MouseEventHandler(changePokemon_Click);
            changePokemon.BackColor = Color.LightGreen;
            changePokemon.ForeColor = Color.Black;
            changePokemon.Font = new Font("Arial", 15, FontStyle.Bold);
            changePokemon.Text = "Vymenit";

            encounter.Controls.Add(changePokemon);

            //zautoceni pokemona [BUTTON]


        }

        private void attackPokemon_Click(object sender, MouseEventArgs e )
        {
            //typy atd pocet poskozeni...
        }

        int x;

        private async void runPokemon_Click(object sender, MouseEventArgs e)
        {
            // sance k uniknuti atd

            x = rnd.Next(2);

            Console.WriteLine(x);

            if (x == 1)
            {
                catchPokemon.Hide();
                attackPokemon.Hide();
                runPokemon.Hide();
                label.Show();
                label.Text = $"wow utekli jste pred {_enemyName}";

                await Task.Delay(1500);

                gameAudio.EncounterAudio(0);

                //zpatky do main formu
                Window.ActiveForm.Focus();
                Controls.ControlEnable = true;

                encounter.Dispose();

            }
            else
            {
                changePokemon.Hide();
                catchPokemon.Hide();
                attackPokemon.Hide();
                runPokemon.Hide();
                label.Show();
                label.Text = $"nedokazali jste se pred {_enemyName} utect!!!!!!!!!!!!!";

                await Task.Delay(1500);

                label.Hide();
                runPokemon.Show();
                attackPokemon.Show();
                catchPokemon.Show();
                changePokemon.Show();
            }


        }

        private void changePokemon_Click(object sender, MouseEventArgs e)
        {

        }

        private void catchPokemon_Click(object sender, MouseEventArgs e)
        {
            // chytnuti pokemona
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

            Rectangle EnemyRectangle = new Rectangle(450, 20, 250, 100);

            e.Graphics.FillRectangle(c, EnemyRectangle);

            Rectangle PlayerRectangle = new Rectangle(0, 200, 250, 100);

            e.Graphics.FillRectangle(c, PlayerRectangle);

        }

    }

}
