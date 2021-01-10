using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;

namespace one_life.Engine
{

    public class Controls
    {
        public static bool ControlEnable { get; set; }
    }


    public class Game : one_life.Engine.Engine
    {

        Player2D player;
        int i = 0;
        Vector2 lastPos = new Vector2(200, 750);
        bool IgnoreInAir = false;

        Debug debug = new Debug();
        private double FPS = 0;
        System.Timers.Timer aTimer = new System.Timers.Timer();

        public Game() : base(new Vector2(1000, 1000), "one life.") { }

        void Timer()
        {
            aTimer.Elapsed += GetFPS;
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }

        private void GetFPS(object sender, ElapsedEventArgs e)
        {
            debug.Send($"{FPS} FPS", 1);
            FPS = 0;
        }

        //override

        public override void OnLoad()
        {
            player = new Player2D(new Vector2(200, 750), new Vector2(45, 65), "Player", Properties.Resources.PlayerRight);
            new Map();

            Controls.ControlEnable = true;

            Timer();
        }

        public override void OnDraw()
        {
            if (player.IsInAir("Brick"))
            {
                if (!IgnoreInAir)
                {
                    player.Position.Y += 2f;
                    debug.Send("PLAYER IS IN AIR", 1);
                }
            }
        }

        public override void OnUpdate()
        {
            FPS++;

            if (CurrentPlayerHP == 0)
            {
                Application.Exit();
                MessageBox.Show("u died");
                return;
            }

            if (player.Position.Y > 1100 || player.Position.X > 1100)
            {
                CurrentPlayerHP--;
            }

            if (player.IsCollingWithEnemy("Godzilla"))
            {
                for (int i = 0; i < 150; i++)
                {
                    player.Position.Y--;
                }
                for (int i = 0; i < 100; i++)
                {
                    player.Position.X = player.Position.X - float.Parse(player.GetAngle("Godzilla").ToString());
                }
                CurrentPlayerHP = CurrentPlayerHP - 15;
            }

        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            debug.Send(e.KeyCode.ToString(), 1);

            if (Controls.ControlEnable == false) return;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (!player.IsInAir("Brick")){
                        player.Position.Y += -200f;
                    }

                    break;

                case Keys.Left:

                    switch (i)
                    {
                        case 0:
                            player.Texture = Properties.Resources.PlayerLeftLeft;
                            i++;
                        break;
                        case 1:
                            player.Texture = Properties.Resources.PlayerLeft;
                            i++;
                        break;
                        case 2:
                            player.Texture = Properties.Resources.PlayerLeftRight;
                            i = 0;
                        break;
                    }

                    player.Position.X += -10f;

                    break;
                case Keys.Right:

                    switch (i)
                    {
                        case 0:
                            player.Texture = Properties.Resources.PlayerRightLeft;
                            i++;
                            break;
                        case 1:
                            player.Texture = Properties.Resources.PlayerRight;
                            i++;
                            break;
                        case 2:
                            player.Texture = Properties.Resources.PlayerRightRight;
                            i = 0;
                            break;
                    }

                    player.Position.X += 10f;
                    break;
            }
            if (player.IsColliding("Brick"))
            {
                player.Position.X = lastPos.X;
                player.Position.Y = lastPos.Y;
            }
            lastPos.X = player.Position.X;
            lastPos.Y = player.Position.Y;


        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            debug.Send(e.KeyCode.ToString(), 1);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.Texture = Properties.Resources.PlayerLeft;
                    break;
                case Keys.Up:
                    break;
                case Keys.Right:
                    player.Texture = Properties.Resources.PlayerRight;
                    break;
                case Keys.Down:
                    break;
            }
        }

    }
}
