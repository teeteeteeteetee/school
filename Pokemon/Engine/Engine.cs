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

        private static List<Shape2D> AllShapes = new List<Shape2D>();

        public Color BackgroundColor = Color.Aqua;
        public Image BackgroundImage = Properties.Resources.grass;


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
            Window.Paint += Renderer;
            Window.BackgroundImage = Properties.Resources.grass;

            onLoad();

            GameLoop = new Thread(gameLoop);
            GameLoop.Start();

            Application.Run(Window);

        }

        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }

        public static void UnRegisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
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

            foreach (Shape2D shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }

        }

        public abstract void onLoad();
        public abstract void onUpdate();
        public abstract void onDraw();

    }
}
