using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pokemon.Engine;
using Pokemon.Object;

namespace Pokemon.Engine
{
    class Game : Pokemon.Engine.Engine
    {

        Shape2D player;

        //deklarace -> vytvareni okenka
        public Game() : base(new Vector2(750, 750), "Pokémon")
        {

        }

        //abstract event
        public override void onLoad()
        {
            Console.WriteLine("yeah yeah");

            player = new Shape2D(new Vector2(10, 10), new Vector2(10, 10), "Player", Player.Model);
        }

        //abstract event
        public override void onDraw()
        {
            BackgroundColor = Color.Black;

        }

        //abstract event
        public override void onUpdate()
        {
            Console.WriteLine("updated");
            
        }

    }
}
