using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Pokemon.Engine
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

        private Vector2 windowSize = new Vector2(1000, 1000);
        private string windowTitle = "Pokémon";
        private Window Window = null;
        private Thread GameLoop = null;

        public static List<Player2D> AllPlayers = new List<Player2D>();
        public static List<Wall2D> AllWalls = new List<Wall2D>();
        public static List<Ground2D> AllGrounds = new List<Ground2D>();
        public static List<Building2D> AllBuildings = new List<Building2D>();

        public Scenes.EncounterControl encounterControl = null;

        public Panel PanelScene = null;
        public Color BackgroundColor = Color.Aqua;
        public Image BackgroundImage = Properties.Resources.grass;


        public Engine(Vector2 windowSize, string windowTitle)
        {
            this.windowSize = windowSize;
            this.windowTitle = windowTitle;
            
            //form

            Window = new Window();

            Window.Size = new Size((int)this.windowSize.X, (int)this.windowSize.Y);
            Window.MaximumSize = new Size((int)this.windowSize.X, (int)this.windowSize.Y);
            Window.MinimumSize = new Size((int)this.windowSize.X, (int)this.windowSize.Y);
            Window.MaximizeBox = false;
            Window.Text = this.windowTitle;
            Window.Paint += Renderer;
            Window.KeyDown += KeyInput;
            Window.KeyUp += KeyRelease;
            Window.BackgroundImage = Properties.Resources.grass;

            onLoad();

            //usercontrol

            encounterControl = new Scenes.EncounterControl();

            encounterControl.Dock = DockStyle.Fill;
            encounterControl.Hide();
            Window.Controls.Add(encounterControl);

            GameLoop = new Thread(gameLoop);
            GameLoop.Start();

            Application.Run(Window);

        }

        public static void RegisterPlayer(Player2D player)
        {
            AllPlayers.Add(player);
        }

        public static void UnRegisterPlayer(Player2D player)
        {
            AllPlayers.Remove(player);
        }
        public static void RegisterWall(Wall2D wall)
        {
            AllWalls.Add(wall);
        }

        public static void UnRegisterWall(Wall2D wall)
        {
            AllWalls.Remove(wall);
        }
        public static void RegisterGround(Ground2D ground)
        {
            AllGrounds.Add(ground);
        }

        public static void UnRegisterGround(Ground2D ground)
        {
            AllGrounds.Remove(ground);
        }
        public static void RegisterBuilding(Building2D building)
        {
            AllBuildings.Add(building);
        }

        public static void UnRegisterBuilding(Building2D building)
        {
            AllBuildings.Remove(building);
        }

        void gameLoop()
        {
            while (GameLoop.IsAlive)
            {
                /*
                 * hra by hodila error protoze gameLoop() se intilializoval
                 * predtim nez se initializovala Application.Run(Window);
                 */
                try
                {
                    //namalujeme predtim
                    onDraw();

                    //budeme refreshovat window i kdyz se mu nechce refreshovat diky invoker
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });

                    onUpdate();

                    /*
                     * window si potrebuje trochu odpocinout jinak 
                     * by nebyl pouzitelny bez toho thread.sleep(1);
                     */
                    Thread.Sleep(1);
                }
                catch
                {
                    Console.WriteLine("hra se nacita");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Ground2D ground in AllGrounds)
            {
                g.DrawImage(ground.Texture, ground.Position.X, ground.Position.Y, ground.Scale.X, ground.Scale.Y);
            }

            foreach (Building2D build in AllBuildings)
            {
                g.DrawImage(build.Texture, build.Position.X, build.Position.Y, build.Scale.X, build.Scale.Y);
            }

            foreach (Player2D player in AllPlayers)
            {
                g.DrawImage(player.Texture, player.Position.X, player.Position.Y, player.Scale.X, player.Scale.Y);
            }

            foreach (Wall2D wall in AllWalls)
            {
                g.DrawImage(wall.Texture, wall.Position.X, wall.Position.Y, wall.Scale.X, wall.Scale.Y);
            }

        }

        private void KeyInput(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        private void KeyRelease(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }
        public abstract void onLoad();
        public abstract void onUpdate();
        public abstract void onDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }
}
