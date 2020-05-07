using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Timers;

namespace SnakeGame
{
    public class GameBoard
    {
        public int Height { get; }
        public int Width { get; }

        public GameBoard(int width, int height)
        {
            Height = height;
            Width = width;
        }

        public void Draw()
        {
            // Left and right border
            for (int i = 1; i < Height + 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(1, i);
                Console.Write('#'); // Left
                Console.SetCursorPosition(Width, i);
                Console.Write("#"); // Right
            }

            // Top and bottom border 
            for (int i = 1; i < Width + 1; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(i, 1);
                Console.Write("#"); // Top
                Console.SetCursorPosition(i, Height);
                Console.Write("#"); // Bottom
            }
        }

    }
}