using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pokemon.Object
{

    public class Player
    {

        string CurrentKey = null;

        //pocet pokemonu v party
        public List<int> Party = new List<int>();

        //smer
        public void Direction(string Input)
        {
            //zapamatuje si klavesu
            CurrentKey = Input;
        }

        public Player()
        {

        }

        public Image Model()
        {

            switch (CurrentKey)
            {
                case "UP": return Properties.Resources.Up;
                case "DOWN": return Properties.Resources.Down;
                case "LEFT": return Properties.Resources.Left;
                case "RIGHT": return Properties.Resources.Right;
                default: return Properties.Resources.Down;
            }
        }


    }
}
