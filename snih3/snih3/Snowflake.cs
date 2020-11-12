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
    class Snowflake
    {
        Random rnd = new Random();

        float x;
        float y;
        float ySpeed;

        double X;
        double angle;

        int width = 5;
        int height = 5;

        int count = 0;

        int temp;

        bool enabled = true;

        public void getAngle(int x, int y)
        {
            //y = polomer
            angle = ((Math.PI * x) / 360) - 3.645;
            //0 - 883

            X = x;
        }

        public bool Enabled 
        {
            get { return Enabled; }
            set { enabled = value; }
        }

        public void ChangeSize(int size)
        {
            width += size;
            height += size;
        }

        public void getLocation()
        {
            x = rnd.Next(0, 900);
            y = rnd.Next(-200, 200);
            ySpeed = rnd.Next(1, 5);
        }

        public void Render(PaintEventArgs e)
        {
            count++;
            if (count == 5)
            {
                if ((rnd.Next(10) - 5) > 0)
                {
                    temp = +1;
                }
                else
                {
                    temp = -1;
                }
                x += temp;
                count = 0;
            }

            x += float.Parse(angle.ToString());

            if (enabled == true)
            {
                e.Graphics.FillEllipse(Brushes.White, x, y, width, height);
            }
            
        }
        public void Move()
        {
            y += ySpeed;
            if (y >= 500)
            {
                y = 0;
            }
            if(x >= 900)
            {
                x = 0;
            } else if (x <= -17 )
            {
                x = 883;
            }
        }
    }
}
