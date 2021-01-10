using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace one_life.Engine
{
    public class Enemy2D
    {

        public Vector2 Position = null;
        public Vector2 Scale = null;
        public Vector2 ShootPosition = null;
        public string Tag = "";
        public Bitmap Texture = null;

        public Enemy2D(Vector2 Position, Vector2 Scale, string Tag, Bitmap Bitmap, Vector2 ShootPosition)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;
            this.ShootPosition = ShootPosition;

            Bitmap bitmap = new Bitmap(Bitmap);
            Texture = bitmap;

            Engine.RegisterEnemy(this);
        }

        public void Unregister(Enemy2D enemy)
        {
            Engine.UnRegisterEnemy(enemy);
        }

    }
}
