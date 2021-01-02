using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace Pokemon.Object
{

    public class Player
    {

        //pocet pokemonu v party + static aby value zustalo v pameti
        public static List<int> Party = new List<int>();

        public void PokemonAdd(int x)
        {
            if (Party.Count == 6) return;

            Party.Add(x);

        }
        public void PokemonRemove(int index)
        {
            Party.Remove(index);
        }

        public int getMainPokemon()
        {

            return Party[0];
        }


        public Player()
        {

        }


    }
}
