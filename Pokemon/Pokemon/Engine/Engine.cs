using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

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


        public Engine(Vector2 windowSize, string windowTitle)
        {
            this.windowSize = windowSize;
            this.windowTitle = windowTitle;
             
            Window = new Window();
            Window.Size = new Size((int)this.windowSize.X, (int)this.windowSize.Y);
            Window.Text = this.windowTitle;

            onLoad();

            Application.Run(Window);

        }

        public void onLoad()
        {

        }

    }
}
