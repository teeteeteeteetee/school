using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pokemon.Engine
{
    public class Player2D
    {

        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public Bitmap Character = null;

        public Player2D(Vector2 Position, Vector2 Scale, string Tag, Bitmap Bitmap)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Bitmap bitmap = new Bitmap(Bitmap);
            Character = bitmap;

            //ulozi objekty do listu, jejich posice velikost a jmeno
            Engine.RegisterPlayer(this);
        }

    }
}
