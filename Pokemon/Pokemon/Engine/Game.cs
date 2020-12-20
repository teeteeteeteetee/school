using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pokemon.Engine;
using Pokemon.Object;
using System.Windows.Forms;
using System.Threading;

namespace Pokemon.Engine
{
    class Game : Pokemon.Engine.Engine
    {

        Player2D player;
        int i = 0;

        //deklarace -> vytvareni okenka
        public Game() : base(new Vector2(750, 750), "Pokémon")
        {

        }

        //abstract event
        public override void onLoad()
        {
            player = new Player2D(new Vector2(25, 35), new Vector2(25, 35), "Player", Properties.Resources.Down);
        }

        //abstract event
        public override void onDraw()
        {
            BackgroundColor = Color.Black;

        }

        //abstract event
        public override void onUpdate()
        {
            //Console.WriteLine("updated");
            
        }

        //klavesnice
        public override void GetKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    if (i == 0)
                    {
                        Thread.Sleep(60);
                        player.Character = Properties.Resources.UpLeftLeg;
                        i++;
                    }
                    else
                    {
                        Thread.Sleep(60);
                        player.Character = Properties.Resources.UpRightLeg;
                        i--;
                    }
                    
                    player.Position.Y += -5f;

                    break;
                case Keys.Down:


                    if (i == 0)
                    {
                        Thread.Sleep(60);
                        player.Character = Properties.Resources.DownLeftLeg;
                        i++;
                    }
                    else
                    {
                        Thread.Sleep(60);
                        player.Character = Properties.Resources.DownRightLeg;
                        i--;
                    }

                    player.Position.Y += 5f;

                    break;
                case Keys.Left:

                    if (i == 0)
                    {
                        Thread.Sleep(60);
                        player.Character = Properties.Resources.LeftLeftLeg;
                        i++;
                    }
                    else
                    {
                        Thread.Sleep(60);
                        player.Character = Properties.Resources.LeftRightLeg;
                        i--;
                    }

                    player.Position.X += -5f;

                    break;
                case Keys.Right:

                    if (i == 0)
                    {
                        Thread.Sleep(60);
                        player.Character = Properties.Resources.RightLeftLeg;
                        i++;
                    }
                    else
                    {
                        Thread.Sleep(60);
                        player.Character = Properties.Resources.RightRightLeg;
                        i--;
                    }

                    player.Position.X += 5f;
                    break;
            }
        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    player.Character = Properties.Resources.Up;

                    break;
                case Keys.Down:

                    player.Character = Properties.Resources.Down;

                    break;
                case Keys.Left:

                    player.Character = Properties.Resources.Left;

                    break;
                case Keys.Right:

                    player.Character = Properties.Resources.Right;

                    break;
            }
        }
    }
}
