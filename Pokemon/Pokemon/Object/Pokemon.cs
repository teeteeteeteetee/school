using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
/*
 * ja nebudu zbytecne psat JSON reader library kdyz na internetu 
 * jsou miliony packages a sam je microsoft pouziva tak nevidim
 * v tom problem
 */
using System.Text.Json;

namespace Pokemon.Object
{

    class Pokemon
    {

        public dynamic getData(int pokemonID, string pokemonName)
        {

            // pokemon data z ./Attributes/pokemon-info.json && pokemon-images.json

            var Request = WebRequest.Create($"https://img.pokemondb.net/sprites/bank/normal/{pokemonName}.png");


            return 0;
        }

        public int ID { get; set; }

        public Pokemon()
        {

        }

    }
}
