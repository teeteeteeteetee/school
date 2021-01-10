using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace one_life.Engine
{
    public class Ground2D
    {

        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public Bitmap Texture = null;

        public Ground2D(Vector2 Position, Vector2 Scale, string Tag, Bitmap Bitmap)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Bitmap bitmap = new Bitmap(Bitmap);
            Texture = bitmap;

            Engine.RegisterGround(this);
        }

    }
}
