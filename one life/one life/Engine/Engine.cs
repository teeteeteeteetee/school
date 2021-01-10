using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace one_life.Engine
{

    class Window : Form
    {

        public Window()
        {
            this.DoubleBuffered = true;
        }

    }

    public abstract class Engine
    {

        Debug debug = new Debug();

        private Vector2 windowSize = new Vector2(1000, 1000);
        private string windowTitle = "one life.";
        private Window Window = null;
        private Thread GameLoop = null;

        public static List<Ground2D> AllGrounds = new List<Ground2D>();
        public static List<Player2D> AllPlayers = new List<Player2D>();
        public static List<Enemy2D> AllEnemies = new List<Enemy2D>();

        public int CurrentPlayerHP = 100;

        public Engine(Vector2 windowSize, string windowTitle)
        {
            this.windowSize = windowSize;
            this.windowTitle = windowTitle;

            Window = new Window();

            Window.Size = new Size((int)this.windowSize.X, (int)this.windowSize.Y);
            Window.MaximumSize = new Size((int)this.windowSize.X, (int)this.windowSize.Y);
            Window.MinimumSize = new Size((int)this.windowSize.X, (int)this.windowSize.Y);
            Window.MaximizeBox = false;
            Window.Text = this.windowTitle;
            Window.BackgroundImage = Properties.Resources.Background;
            Window.Paint += Renderer;
            Window.KeyDown += KeyInput;
            Window.KeyUp += KeyRelease;
            
            OnLoad();

            GameLoop = new Thread(gameLoop);
            GameLoop.Start();

            Application.Run(Window);

            debug.Send("Loading game...", 1);

        }

        public static void RegisterPlayer(Player2D player)
        {
            AllPlayers.Add(player);
        }

        public static void UnRegisterPlayer(Player2D player)
        {
            AllPlayers.Remove(player);
        }

        public static void RegisterGround(Ground2D ground)
        {
            AllGrounds.Add(ground);
        }
        public static void UnRegisterGround(Ground2D ground)
        {
            AllGrounds.Remove(ground);
        }

        public static void RegisterEnemy(Enemy2D enemy)
        {
            AllEnemies.Add(enemy);
        }
        public static void UnRegisterEnemy(Enemy2D enemy)
        {
            AllEnemies.Remove(enemy);
        }

        void gameLoop()
        {
            while (GameLoop.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Invalidate(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    debug.Send("Loading game...", 1);
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Window.BackColor = Color.Black;

            Graphics g = e.Graphics;

            foreach (Enemy2D enemy in AllEnemies)
            {
                g.DrawImage(enemy.Texture, enemy.Position.X, enemy.Position.Y, enemy.Scale.X, enemy.Scale.Y);
            }
            foreach (Player2D player in AllPlayers)
            {
                g.DrawImage(player.Texture, player.Position.X, player.Position.Y, player.Scale.X, player.Scale.Y);
            }

            foreach (Ground2D ground in AllGrounds)
            {
                g.DrawImage(ground.Texture, ground.Position.X, ground.Position.Y, ground.Scale.X, ground.Scale.Y);
            }

            Pen pen = new Pen(Color.Green);
            SolidBrush green = new SolidBrush(Color.Green);

            Rectangle PlayerHealthBar = new Rectangle(10, 10, 225, 10);
            Rectangle PlayerHealthProgress = new Rectangle();
            PlayerHealthProgress.X = PlayerHealthBar.X;
            PlayerHealthProgress.Y = PlayerHealthBar.Y;
            PlayerHealthProgress.Width = PlayerHealthBar.Width * (Percent(100, CurrentPlayerHP)) / 100;
            PlayerHealthProgress.Height = PlayerHealthBar.Height;

            e.Graphics.DrawRectangle(pen, PlayerHealthBar);
            e.Graphics.FillRectangle(green, PlayerHealthProgress);

        }

        private int Percent(double total, double current)
        {
            return (int)((current / total) * 100);
        }

        private void KeyInput(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        private void KeyRelease(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }


}
