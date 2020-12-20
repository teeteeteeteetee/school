using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pokemon.Engine
{
    public class Building2D
    {

        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public Bitmap Texture = null;

        public Building2D(Vector2 Position, Vector2 Scale, string Tag, Bitmap Bitmap)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Bitmap bitmap = new Bitmap(Bitmap);
            Texture = bitmap;

            //ulozi objekty do listu, jejich pozice velikost a jmeno
            Engine.RegisterBuilding(this);
        }

    }
}
