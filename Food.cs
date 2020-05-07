using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Timers;

namespace SnakeGame
{
    public class Food
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; }
        public int Height { get; }

        public Food(int width, int height)
        {
            Width = width;
            Height = height;
            MakeFood(width, height);
        }

        public void MakeFood(int width, int height)
        {
            var randomPosition = new Random();
            X = randomPosition.Next(2, width - 2);
            Y = randomPosition.Next(2, height - 2);
        }

        public void DrawFood()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("O");
        }

        public bool FoodWasEaten(int snakeX, int snakeY, int foodX, int foodY)
        {
            if (snakeX == foodX && snakeY == foodY)
            {
                return true;
            }

            return false;
        }
    }
}