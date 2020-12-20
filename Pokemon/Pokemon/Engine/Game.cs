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

        Vector2 lastPos = new Vector2(85, 85);


        //https://docs.microsoft.com/en-us/dotnet/api/system.array?view=net-5.0
        //multi dimensionalni array


        /// <summary>
        /// 
        /// e = treeUp
        /// t = tree
        /// f = treeDown
        /// g = grassWild
        /// h = buildingPokeHeal
        /// 
        /// 
        /// </summary>

        int i = 0;

        //deklarace -> vytvareni okenka
        public Game() : base(new Vector2(750, 750), "Pokémon")
        {

        }

        //abstract event
        public override void onLoad()
        {

            player = new Player2D(new Vector2(85, 85), new Vector2(45, 65), "Player", Properties.Resources.Down);

            new Map();

        }

        //abstract event
        public override void onDraw()
        {
            BackgroundColor = Color.Black;

        }

        //abstract event
        public override void onUpdate()
        {
            
        }

        //klavesnice ovladani pres sipky
        public override void GetKeyDown(KeyEventArgs e)
        {

            //Thread.Sleep(35);
  
            switch (e.KeyCode)
            {
                case Keys.Up:

                    if (i == 0)
                    {
                        player.Texture = Properties.Resources.UpLeftLeg;
                        i++;
                    }
                    else
                    {
                        player.Texture = Properties.Resources.UpRightLeg;
                        i--;
                    }
                    
                    player.Position.Y += -5f;

                    break;
                case Keys.Down:

                    if (i == 0)
                    {
                        player.Texture = Properties.Resources.DownLeftLeg;
                        i++;
                    }
                    else
                    {
                        player.Texture = Properties.Resources.DownRightLeg;
                        i--;
                    }

                    player.Position.Y += 5f;

                    break;
                case Keys.Left:

                    if (i == 0)
                    {
                        player.Texture = Properties.Resources.LeftLeftLeg;
                        i++;
                    }
                    else
                    {
                        player.Texture = Properties.Resources.LeftRightLeg;
                        i--;
                    }

                    player.Position.X += -5f;

                    break;
                case Keys.Right:

                    if (i == 0)
                    {
                        player.Texture = Properties.Resources.RightLeftLeg;
                        i++;
                    }
                    else
                    {
                        player.Texture = Properties.Resources.RightRightLeg;
                        i--;
                    }

                    player.Position.X += 5f;
                    break;
            }

            //stromy
            if (player.IsColliding("Tree"))
            {
                player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }

            //budovy
            if (player.IsColliding("PokeCenter"))
            {
                player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }
            

            lastPos.X = player.Position.X;
            lastPos.Y = player.Position.Y;

            player.IsWalking("Grass");

        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:

                    player.Texture = Properties.Resources.Up;

                    break;
                case Keys.Down:

                    player.Texture = Properties.Resources.Down;

                    break;
                case Keys.Left:

                    player.Texture = Properties.Resources.Left;

                    break;
                case Keys.Right:

                    player.Texture = Properties.Resources.Right;

                    break;
            }
        }
    }
}
