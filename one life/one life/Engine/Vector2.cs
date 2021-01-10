using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace one_life.Engine
{
    public class Vector2
    {

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

        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }

    }
}
