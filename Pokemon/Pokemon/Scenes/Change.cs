using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Media;
using Pokemon.Engine;

namespace Pokemon.Scenes
{
    public class ChangeControl : UserControl
    {

        public ChangeControl()
        {
            this.DoubleBuffered = true;
        }

    }

    public class Change
    {

        private ChangeControl change = null;

        public void Run()
        {
            change.BackColor = Color.Gray;
            change.Width = Window.ActiveForm.Width;
            change.Height = Window.ActiveForm.Height;

            Window.ActiveForm.Controls.Add(change);

        }


        public Change()
        {

        }
    }
}
