using System;
using System.Threading;

using SnakeLib;

namespace Test
{
    class Program
    {
        static string Get(int i) =>
            i switch
            {
                1 => "O",
                2 => "X",
                _ => " ",
            };

        static Direction Dir(ConsoleKey key) =>
            key switch
            {
                ConsoleKey.UpArrow => Direction.up,
                ConsoleKey.DownArrow => Direction.down,
                ConsoleKey.LeftArrow => Direction.left,
                ConsoleKey.RightArrow => Direction.right,
            };

        static void Main(string[] args)
        {
            int[,] field;

            Snake snake = new Snake(20, 20, 1, 1);

            while (true)
            {
                string buffer = "";

                field = new int[20, 20];

                if (!snake.Alive)
                    break;

                foreach (var b in snake.Body)
                    field[b.X, b.Y] = 1;
                field[snake.Food.X, snake.Food.Y] = 2;

                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                        buffer += Get(field[j, i]);
                    buffer += "|\n";
                }

                for (int i = 0; i < 20; i++)
                    buffer += "-";

                Console.Clear();
                Console.WriteLine(buffer);

                Thread.Sleep(200);

                if (Console.KeyAvailable)
                {
                    snake.Direction = Dir(Console.ReadKey(true).Key);
                }

                snake.Move();
            }

            Console.WriteLine("GAME OVER");
        }
    }
}
