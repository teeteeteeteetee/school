using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pokemon.Engine
{
    public class Vector2
    {
        // souradnice X a Y
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2()
        {
            X = Zero().X;
            Y = Zero().Y;
        }


        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        //vrati X a Y na 0
        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

    }
}
