using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Engine
{
    public class Map
    {

        //https://docs.microsoft.com/en-us/dotnet/api/system.array.getlength?view=net-5.0

        string[,] _Map =
            {
                {"e", "e", "e", "e", "e", "e", "e", "e", "e", "e",  "e",  "e",  "e", "e", "e", "e" },
                {"t", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "t" },
                {"t", ".", "g", "g", "g", "g", ".", ".", ".", ".",  "t",  "t",  ".", ".", ".", "t" },
                {"t", "g", "g", "t", "t", "t", ".", "g", ".", ".",  ".",  "t",  ".", ".", ".", "t" },
                {"t", "g", "g", "t", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "t" },
                {"t", "g", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "t" },
                {"t", "g", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "t" },
                {"t", ".", "g", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "t" },
                {"t", ".", ".", "g", ".", ".", "t", ".", ".", ".",  ".",  ".",  ".", ".", ".", "t" },
                {"t", ".", ".", ".", ".", ".", ".", ".", ".", ".", "ha", "hb", "hc", ".", ".", "t" },
                {"t", ".", ".", "t", ".", ".", ".", ".", ".", ".", "hd", "he", "hf", ".", ".", "t" },
                {"t", ".", ".", ".", ".", ".", ".", ".", ".", ".", "hg", "hh", "hi", ".", ".", "t" },
                {"t", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "t" },
                {"t", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "t" },
                {"f", "f", "f", "f", "f", "f", "f", "f", "f", "f",  "f",  "f",  "f", "f", "f", "f" }
            };

        public Map()
        {
            for (int i = 0; i < _Map.GetLength(0); i++)
            {
                for (int j = 0; j < _Map.GetLength(1); j++)
                {

                    if(_Map[i, j] == "t")
                    {
                        new Wall2D(new Vector2(j * 45, i * 45), new Vector2(55, 75), "Tree", Properties.Resources.tree);
                    }
                    if (_Map[i, j] == "e")
                    {
                        new Wall2D(new Vector2(j * 45, i * 45), new Vector2(55, 75), "Tree", Properties.Resources.treeUp);
                    }
                    if (_Map[i, j] == "f")
                    {
                        new Wall2D(new Vector2(j * 45, i * 45), new Vector2(55, 75), "Tree", Properties.Resources.treeDown);
                    }
                    if (_Map[i, j] == "g")
                    {
                        new Ground2D(new Vector2(j * 45, i * 45), new Vector2(48, 48), "Grass", Properties.Resources.grassWild);
                    }

                    //pokecenter
                    if (_Map[i, j] == "ha")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenter", Properties.Resources.buildingPokeCenter_0_0);
                    }
                    if (_Map[i, j] == "hb")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenter", Properties.Resources.buildingPokeCenter_1_0);
                    }
                    if (_Map[i, j] == "hc")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenter", Properties.Resources.buildingPokeCenter_2_0);
                    }
                    if (_Map[i, j] == "hd")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenter", Properties.Resources.buildingPokeCenter_0_1);
                    }
                    if (_Map[i, j] == "he")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenter", Properties.Resources.buildingPokeCenter_1_1);
                    }
                    if (_Map[i, j] == "hf")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenter", Properties.Resources.buildingPokeCenter_2_1);
                    }
                    if (_Map[i, j] == "hg")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenterSide", Properties.Resources.buildingPokeCenter_0_2);
                    }
                    if (_Map[i, j] == "hh")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenterDoor", Properties.Resources.buildingPokeCenter_1_2);
                    }
                    if (_Map[i, j] == "hi")
                    {
                        new Building2D(new Vector2(j * 45, i * 45), new Vector2(45, 45), "PokeCenterSide", Properties.Resources.buildingPokeCenter_2_2);
                    }

                }
            }
        }

    }
}
