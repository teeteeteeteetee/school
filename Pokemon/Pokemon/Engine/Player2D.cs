using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pokemon.Object;
using Pokemon.Scenes;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace Pokemon.Engine
{
    public class Player2D
    {

        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public Bitmap Texture = null;

        Random rnd = new Random();
        Object.Pokemon obj = new Object.Pokemon();

        int i = 0;

        public Player2D(Vector2 Position, Vector2 Scale, string Tag, Bitmap Bitmap)
        {
            this.Position = Position;
            this.Scale = Scale;
            this.Tag = Tag;

            Bitmap bitmap = new Bitmap(Bitmap);
            Texture = bitmap;

            //ulozi objekty do listu, jejich pozice velikost a jmeno
            Engine.RegisterPlayer(this);
        }

        public bool IsColliding(string tag)
        {
            foreach (Wall2D a in Engine.AllWalls)
            {
                if(a.Tag == tag)
                {
                    if (Position.X < a.Position.X + a.Scale.X / 2 &&
                        Position.X + Scale.X /2 > a.Position.X &&
                        Position.Y < a.Position.Y + a.Scale.Y / 1.5 &&
                        Position.Y + Scale.Y / 1.5 > a.Position.Y) return true;
                }

            }
            foreach (Building2D a in Engine.AllBuildings)
            {
                if (a.Tag == tag)
                {

                    if (Position.X < a.Position.X + a.Scale.X / 2 &&
                        Position.X + Scale.X / 2 > a.Position.X &&
                        Position.Y < a.Position.Y + a.Scale.Y &&
                        Position.Y + Scale.Y > a.Position.Y) return true;
                }

            }

            return false;

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
                        Position.Y + Scale.Y / 2> a.Position.Y) 
                    {
                        if(i == 0)
                        {
                            a.Texture = Properties.Resources.grassWildLeft;
                            i++;
                        }
                        else
                        {
                            a.Texture = Properties.Resources.grassWildRight;
                            i--;
                        }

                        //utok pokemona -> vyvolani funkci
                        if (rnd.Next(0, 100) >= 97) {

                            //var Enemy = obj.getRandomPokemon();

                            var RAWJSON = obj.getRandomPokemon();

                            using (JsonDocument document = JsonDocument.Parse(RAWJSON))
                            {
                                Scenes.Encounter enc = new Scenes.Encounter();

                                JsonElement DATA = document.RootElement;

                                Console.WriteLine(DATA.GetProperty("name"));
                                Console.WriteLine(DATA.GetProperty("id"));

                                enc.Run(DATA.GetProperty("name").ToString(), DATA.GetProperty("id").ToString());

                            }


                        }

                        return true;
                    };
                }

            }

            return false;

        }

    }
}
