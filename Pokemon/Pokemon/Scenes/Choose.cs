using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;

using Pokemon.Engine;

namespace Pokemon.Scenes
{

    public class ChooseControl : UserControl
    {
        public ChooseControl()
        {
            this.DoubleBuffered = true;
        }

    }

    public class Choose
    {
        private ChooseControl choose = null;

        Object.Player pkmn = new Object.Player();

        //zvuky
        Audio.Audio gameAudio = new Audio.Audio();

        PictureBox bulbasaur = new PictureBox();
        PictureBox charmander = new PictureBox();
        PictureBox squirle = new PictureBox();

        public async void Run()
        {

            //vytvoreni usercontrol
            choose = new ChooseControl();

            Controls.ControlEnable = false;

            await Task.Delay(50);

            choose.Width = Window.ActiveForm.Width;
            choose.Height = Window.ActiveForm.Height;

            Window.ActiveForm.Controls.Add(choose);

            await Task.Delay(100);


            choose.BackColor = Color.Black;


            //1
            bulbasaur.LoadAsync(@"https://img.pokemondb.net/sprites/diamond-pearl/normal/bulbasaur.png");
            bulbasaur.Location = new Point(50, 100);
            bulbasaur.Size = new Size(200, 200);
            bulbasaur.SizeMode = PictureBoxSizeMode.StretchImage;
            bulbasaur.BackColor = Color.Transparent;

            choose.Controls.Add(bulbasaur);

            Label bulbasaurText = new Label();

            bulbasaurText.Text = "Bulbasaur";
            bulbasaurText.Location = new Point(120, 300);
            bulbasaurText.Size = new Size(20, 20);
            bulbasaurText.ForeColor = Color.White;
            bulbasaurText.TextAlign = ContentAlignment.MiddleCenter;
            bulbasaurText.AutoSize = true;

            bulbasaur.MouseEnter += new EventHandler(bulbasaurHover);
            bulbasaur.MouseLeave += new EventHandler(small);
            bulbasaur.MouseClick += new MouseEventHandler(bulbasaurClick);

            choose.Controls.Add(bulbasaurText);

            //4
            charmander.LoadAsync(@"https://img.pokemondb.net/sprites/diamond-pearl/normal/charmander.png");
            charmander.Location = new Point(250, 100);
            charmander.Size = new Size(200, 200);
            charmander.SizeMode = PictureBoxSizeMode.StretchImage;
            charmander.BackColor = Color.Transparent;

            charmander.MouseEnter += new EventHandler(charmanderHover);
            charmander.MouseLeave += new EventHandler(small);
            charmander.MouseClick += new MouseEventHandler(charmanderClick);

            choose.Controls.Add(charmander);

            Label charmanderText = new Label();

            charmanderText.Text = "Charmander";
            charmanderText.Location = new Point(320, 305);
            charmanderText.Size = new Size(20, 20);
            charmanderText.ForeColor = Color.White;
            charmanderText.TextAlign = ContentAlignment.MiddleCenter;
            charmanderText.AutoSize = true;

            choose.Controls.Add(charmanderText);

            //7
            squirle.LoadAsync(@"https://img.pokemondb.net/sprites/diamond-pearl/normal/squirtle.png");
            squirle.Location = new Point(450, 100);
            squirle.Size = new Size(200, 200);
            squirle.SizeMode = PictureBoxSizeMode.StretchImage;
            squirle.BackColor = Color.Transparent;

            squirle.MouseEnter += new EventHandler(squirleHover);
            squirle.MouseLeave += new EventHandler(small);
            squirle.MouseClick += new MouseEventHandler(squirleClick);

            choose.Controls.Add(squirle);

            Label squirleText = new Label();

            squirleText.Text = "Squirtle";
            squirleText.Location = new Point(520, 300);
            squirleText.Size = new Size(20, 20);
            squirleText.ForeColor = Color.White;
            squirleText.TextAlign = ContentAlignment.MiddleCenter;
            squirleText.AutoSize = true;

            choose.Controls.Add(squirleText);



        }

        private void bulbasaurHover(object sender, EventArgs e)
        {
            gameAudio.AudioPlay(Properties.Resources.bulbasaur);
            bulbasaur.Size = new Size(250, 250);
        }

        private void charmanderHover(object sender, EventArgs e)
        {
            gameAudio.AudioPlay(Properties.Resources.charmander);
            charmander.Size = new Size(250, 250);
        }

        private void squirleHover(object sender, EventArgs e)
        {
            gameAudio.AudioPlay(Properties.Resources.squirle);
            squirle.Size = new Size(250, 250);
        }

        //kliknuti

        private void bulbasaurClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Controls.ControlEnable = true;
                pkmn.PokemonAdd(1);
                choose.Dispose();
            }
        }

        private void charmanderClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Controls.ControlEnable = true;
                pkmn.PokemonAdd(4);
                choose.Dispose();
            }
        }

        private void squirleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Controls.ControlEnable = true;
                pkmn.PokemonAdd(7);
                choose.Dispose();
            }
        }

        private void small(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Size = new Size(200, 200);
        }

    }

}
