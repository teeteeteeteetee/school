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
        public Bitmap Texture = null;

        public Player2D(Vector2 Position, Vector2 Scale, string Tag, Bitmap Bitmap)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Bitmap bitmap = new Bitmap(Bitmap);
            Texture = bitmap;

            //ulozi objekty do listu, jejich posice velikost a jmeno
            Engine.RegisterPlayer(this);
        }

        public bool IsColliding(string tag)
        {
            foreach (Wall2D a in Engine.AllWalls)
            {
                if(a.Tag == tag)
                {
                    if (Position.X < a.Position.X + a.Scale.X /2 &&
                        Position.X + Scale.X /4 > a.Position.X &&
                        Position.Y < a.Position.Y + a.Scale.Y /2 &&
                        Position.Y + Scale.Y /4 > a.Position.Y) return true;
                }

            }

            return false;

        }

    }
}
