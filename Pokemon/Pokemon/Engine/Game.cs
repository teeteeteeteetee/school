using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pokemon.Engine;

namespace Pokemon.Engine
{
    class Game : Pokemon.Engine.Engine
    {
        //deklarace -> vytvareni okenka
        public Game() : base(new Vector2(750, 750), "Pokémon")
        {

        }

        //abstract event
        public override void onLoad()
        {
            Console.WriteLine("yeah yeah");
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
