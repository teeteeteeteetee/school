using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;

namespace one_life.Engine
{
    public class Map
    {

        System.Timers.Timer move = new System.Timers.Timer();
        System.Timers.Timer Spawntimer = new System.Timers.Timer();

        bool Right = true;

        Debug debug = new Debug();

        Ground2D MoveBrick;
        Enemy2D Milk;
        Enemy2D UFO;
        Enemy2D Godzilla;

        Random rnd = new Random();

        //https://docs.microsoft.com/cs-cz/dotnet/csharp/programming-guide/arrays/multidimensional-arrays 2D

        string[,] _Map =
            {
                {"w", "w", "w", "w", "w", "w", "w", "w", "w", "w",  "w",  "w",  "w", "w", "w", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  "b",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  "b",  "b",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", "m",  ".",  "b",  ".", ".", ".", "w" },
                {"w", ".", ".", ".", ".", ".", ".", ".", ".", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", "b", "b", "b", "b", "b", "b", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", ".", ".", "b", "b", "b", "b", "b", "b", ".",  ".",  ".",  ".", ".", ".", "w" },
                {"w", "w", "b", "b", "b", "b", "b", "b", "b", "w",  "w",  "w",  "w", "w", "w", "w" }
            };

        public Map()
        {

            MoveBrick = new Ground2D(new Vector2(400, 675), new Vector2(55, 55), "Brick", Properties.Resources.Brick);

            move.Enabled = true;
            move.Interval = 100;
            move.Elapsed += Move;
            move.Start();
            StartTimer();

            for (int i = 0; i < _Map.GetLength(0); i++)
            {
                for (int j = 0; j < _Map.GetLength(1); j++)
                {
                    if (_Map[i, j] == "b")
                    {
                        new Ground2D(new Vector2(j * 55, i * 55), new Vector2(55, 55), "Brick", Properties.Resources.Brick);
                    }

                }
            }
        }

        private void StartTimer()
        {
            debug.Send("Started Boss Timer", 1);
            Spawntimer.Interval = 30000;
            Spawntimer.Enabled = true;
            Spawntimer.Elapsed += Spawn;
            Spawntimer.Start();

        }

        void Spawn(object sender, ElapsedEventArgs e)
        {
            SpawnGodzilla();

            /*switch (rnd.Next(0,3))
            {
                case 0:
                    SpawnGodzilla();
                    break;
                case 1:
                    SpawnMilk();
                    break;
                case 2:
                    SpawnUFO();
                    break;
            }*/
        }

        async void SpawnGodzilla()
        {
            debug.Send("Spawned Godzilla", 1);
            Godzilla = new Enemy2D(new Vector2(1000, 1000), new Vector2(500, 500), "Godzilla", Properties.Resources.Godzilla, new Vector2(100,100));
            await Task.Delay(2000);
            for (int i = 0; i < 300; i++)
            {
                Godzilla.Position.Y--;
                Godzilla.Position.X--;

                Thread.Sleep(1);
            }
            for (int i = 0; i < 90; i++)
            {
                Godzilla.Position.Y--;
                Thread.Sleep(1);
            }

            await Task.Delay(2000);

            for (int y = 0; y < 10; y++)
            {
                for (int i = 0; i < 50; i++)
                {
                    Godzilla.Position.Y++;
                    Godzilla.Position.X--;
                    Thread.Sleep(1);
                }
                for (int i = 0; i < 50; i++)
                {
                    Godzilla.Position.Y--;
                    Godzilla.Position.X--;
                    Thread.Sleep(1);
                }
                Thread.Sleep(1);
            }

            await Task.Delay(2000);
            debug.Send("Despawned Godzilla", 1);
            Godzilla.Unregister(Godzilla);
            
        }
        async void SpawnMilk()
        {
            debug.Send("Spawned Milk", 1);
            Milk = new Enemy2D(new Vector2(800, 400), new Vector2(200, 300), "Godzilla", Properties.Resources.Milk, new Vector2(100, 100));

            await Task.Delay(2000);
            Milk.Unregister(Milk);
        }
        async void SpawnUFO()
        {
            debug.Send("Spawned UFO", 1);
            UFO = new Enemy2D(new Vector2(800, 0), new Vector2(200, 200), "Godzilla", Properties.Resources.UFO, new Vector2(100, 100))  ;

            await Task.Delay(2000);
            UFO.Unregister(UFO);
        }

        void Move(object sender, ElapsedEventArgs e)
        {

            if (Right)
            {
                MoveBrick.Position.X += 1;
            }
            else
            {
                MoveBrick.Position.X -= 1;
            }

            if(MoveBrick.Position.X == 450)
            {
                Right = false;
            }

            if(MoveBrick.Position.X == 400)
            {
                Right = true;
            }

        }
    }

}
