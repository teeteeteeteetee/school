using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace one_life.Engine
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

            Engine.RegisterPlayer(this);
        }

        public bool IsColliding(string tag)
        {

            foreach (Ground2D a in Engine.AllGrounds)
            {
                if (a.Tag == tag)
                {

                    if (Position.X < a.Position.X + a.Scale.X &&
                        Position.X + Scale.X > a.Position.X &&
                        Position.Y < a.Position.Y + a.Scale.Y &&
                        Position.Y + Scale.Y > a.Position.Y) return true;
                }

            }

            return false;

        }
        public bool IsInAir(string tag)
        {
            foreach (Ground2D a in Engine.AllGrounds)
            {
                if (a.Tag == tag)
                {
                    if (Position.X < a.Position.X + a.Scale.X &&
                        Position.X + Scale.X > a.Position.X &&
                        Position.Y + 1 < a.Position.Y + a.Scale.Y &&
                        Position.Y + 1 + Scale.Y > a.Position.Y) 
                    {
                        return false; 
                    }
                }

            }

            return true;
        }

        public bool IsWalking(string tag)
        {

            foreach (Ground2D a in Engine.AllGrounds)
            {

                if (a.Tag == tag)
                {
                    if (Position.X < a.Position.X + a.Scale.X / 2 &&
                        Position.X + Scale.X / 2 > a.Position.X &&
                        Position.Y < a.Position.Y + a.Scale.Y / 2 &&
                        Position.Y + Scale.Y / 2 > a.Position.Y)
                    {

                        return true;
                    };
                }

            }

            return false;

        }

        public double GetAngle(string tag)
        {
            foreach (Enemy2D a in Engine.AllEnemies)
            {
                if(a.Tag == tag)
                {
                    //https://files.loli.support/i/06p2p.png

                    //formula 2*PI / 360 stupnu

                    return ((Math.Atan2(a.Position.Y, a.Position.X) - Math.Atan2(Position.Y, Position.X)) * (180 / Math.PI));

                }
            }

            return 0;

        }

        public bool IsCollingWithEnemy(string Tag)
        {
            foreach (Enemy2D a in Engine.AllEnemies)
            {
                if (Position.X < a.Position.X + a.Scale.X &&
                    Position.X + Scale.X > a.Position.X &&
                    Position.Y < a.Position.Y + a.Scale.Y &&
                    Position.Y + Scale.Y > a.Position.Y) return true;
            }

            return false;
        }

    }
}
