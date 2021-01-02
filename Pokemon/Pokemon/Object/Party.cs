using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Object
{
    public class Party
    {

        //party
        public static List<int> pkmnParty = new List<int>();

        public void PokemonAdd(int x)
        {
            if (pkmnParty.Count == 6) return;

            pkmnParty.Add(x);

        }
        public void PokemonRemove(int index)
        {
            pkmnParty.Remove(index);
        }

        public int MainPokemon()
        {
            return pkmnParty[0];
        }



    }
}
