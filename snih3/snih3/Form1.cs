using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace snih3
{
    public partial class app : Form
    {

        Snowflake[] drops = new Snowflake[100];

        public app()
        {
            InitializeComponent();
        }

        private void app_Load(object sender, EventArgs e)
        {
            MessageBox.Show("[Šipka Nahoru] Zvětšit vločky\n[Šipka Dolu] Zmenšit vločky\n[Šipka Vlevo] Den\n[Šipka Vpravo] Noc\n[ESC] Vypnout Snih\n[ENTER] Zapnout Snih");
            for (int i = 0; i < drops.Length; i++)
            {
                drops[i] = new Snowflake();
                drops[i].getLocation();
                Thread.Sleep(10);
            }
        }

        private void app_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < drops.Length; i++)
            {
                drops[i].Move();
                drops[i].Render(e);
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void app_MouseMove(object sender, MouseEventArgs e)
        {

            var position = this.PointToClient(Cursor.Position);

            //drops[1].getAngle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y));

            for (int i = 0; i < drops.Length; i++)
            {
                drops[i].getAngle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y));
            }


            //0 - 459
            double change = position.Y / 100;
            double x = Math.Floor(change);
            switch (x)
            {
                case 0:
                    timer.Interval = 30;
                    break;
                case 1:
                    timer.Interval = 25;
                    break;
                case 2:
                    timer.Interval = 20;
                    break;
                case 3:
                    timer.Interval = 15;
                    break;
                case 4:
                    timer.Interval = 10;
                    break;
            }
        }

        private void app_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    for (int i = 0; i < drops.Length; i++)
                    {
                        drops[i].ChangeSize(1);
                    }
                    break;
                case Keys.Down:
                    for (int i = 0; i < drops.Length; i++)
                    {
                        drops[i].ChangeSize(-1);
                    }
                    break;
                case Keys.Left:
                    BackColor = Color.FromArgb(173, 216, 230);
                    break;
                case Keys.Right:
                    BackColor = Color.FromArgb(0, 0, 0);
                    break;
                case Keys.Escape:
                    for (int i = 0; i < drops.Length; i++)
                    {
                        drops[i].Enabled = false;
                    }
                    break;
                case Keys.Enter:
                    for (int i = 0; i < drops.Length; i++)
                    {
                        drops[i].Enabled = true;
                    }
                    break;
            }
        }
    }
}
