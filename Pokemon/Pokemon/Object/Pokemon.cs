using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;

/*
 * ja nebudu zbytecne psat JSON reader library kdyz na internetu 
 * jsou miliony packages, ktery je microsoft pouziva tak nevidim
 * v tom problem
 */
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pokemon.Object
{

    public class Pokemon
    {

        Random rnd = new Random();

        public dynamic getRandomPokemon()
        {
            
            var RAWJSON = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Object\\Attributes\\pokemon-info.json");
            using (JsonDocument document = JsonDocument.Parse(RAWJSON))
            {
                JsonElement DATA = document.RootElement;


                //Console.WriteLine(DATA.GetProperty("1"));

                //Console.WriteLine(DATA.GetArrayLength()); //151
                //Console.WriteLine(DATA[rnd.Next(0, DATA.GetArrayLength())]);
                /*
                 "id": "01",
                 "name": "Bulbasaur",
                 "species": "Seed Pokémon",
                 "type": [
                    "Grass",
                    "Poison"
                 ] 
                 */

                //Console.WriteLine(DATA[rnd.Next(0, DATA.GetArrayLength())]);

                return DATA[rnd.Next(0, DATA.GetArrayLength())].ToString();

            }



        }

        public string getPokemonNameByID(int x)
        {
            var RAWJSON = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Object\\Attributes\\pokemon-info.json");
            using (JsonDocument document = JsonDocument.Parse(RAWJSON))
            {
                JsonElement DATA = document.RootElement;



                var SELECTED = DATA[x];

                return SELECTED.GetProperty("name").ToString();

            }
        }

        public dynamic getData(int pokemonID, string pokemonName)
        {

            // pokemon data z ./Attributes/pokemon-info.json && pokemon-images.json



            //var Request = WebRequest.Create($"https://img.pokemondb.net/sprites/bank/normal/{pokemonName}.png");


            return 0;
        }

        public int ID { get; set; }

        public Pokemon()
        {
            getRandomPokemon();
        }

    }
}
