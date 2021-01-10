using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace one_life.Engine
{
    public class Debug
    {
        public static bool Enabled { get; set; } = true;

        public void Send(string Text, int Type)
        {
            if (Enabled)
            {
                Message(Text, Type);
            }
        }

        public void Send(int Number, int Type)
        {
            if (Enabled)
            {
                Message(Number.ToString(), Type);
            }
        }

        public void Send(double Double, int Type)
        {
            if (Enabled)
            {
                Message(Double.ToString(), Type);
            }
        }

        public void Send(bool Bool, int Type)
        {
            if (Enabled)
            {
                Message(Bool.ToString(), Type);
            }
        }

        private void Message(string Text, int Type)
        {
            switch (Type)
            {
                //info
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[INFO]: {Text}");
                    Console.ResetColor();
                    break;

                //warn
                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[WARN]: {Text}");
                    Console.ResetColor();
                    break;

                //error
                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[ERROR]: {Text}");
                    break;
            }
        }
        public Debug()
        {

        }
    }
}
