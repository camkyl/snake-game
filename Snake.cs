using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Timers;

namespace SnakeGame
{
    public class Snake
    {
            public int SnakeX { get; set; }
            public int SnakeY { get; set; }
            public int Score { get; }
            public List<(int, int)> Body { get; }
            public Snake(int x, int y, int score)
            {
                SnakeX = x;
                SnakeY = y;
                Score = score;
                Body = new List<(int, int)> { };

                // Adds the initial body parts to snake body
                for (var i = Score; i >= 1; i--)
                {
                    Body.Add((SnakeX - i, SnakeY));
                }
            }
            
            public void DrawSnake()
            {
                foreach (var bodyPart in Body)
                {
                    Console.SetCursorPosition(bodyPart.Item1, bodyPart.Item2);
                }

                Console.SetCursorPosition(SnakeX, SnakeY);
                Console.Write("x");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }

            public void MoveSnakeBody(bool isFoodEaten)
            {
                if (!isFoodEaten)
                {
                    var endOfBodyX = Body.Last().Item1;
                    var endOfBodyY = Body.Last().Item2;
                    Console.SetCursorPosition(endOfBodyX, endOfBodyY);
                    Console.Write(" ");
                    Body.Remove(Body.Last());
                }

                Body.Insert(0, (SnakeX, SnakeY));
            }
            
            public void Movement(ConsoleKey key)
            {
                if (key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(SnakeX, SnakeY);
                    SnakeY--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(SnakeX, SnakeY);
                    SnakeY++;
                }
                else if (key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(SnakeX, SnakeY);
                    SnakeX--;
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    Console.SetCursorPosition(SnakeX, SnakeY);
                    SnakeX++;
                }

                Console.SetCursorPosition(SnakeX, SnakeY);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }

            public bool SnakeCollidedWithWall(int snakeX, int snakeY, int height, int width)
            {
                if (snakeX == 1 || snakeX == width - 1 || snakeY == 1 || snakeY == height - 1)
                {
                    return true;
                }

                return false;
            }

            public bool SnakeCollidedWithItself(int X, int Y)
            {
                if (Body.Any(bodyPart => bodyPart.Item1 == X && bodyPart.Item2 == Y))
                {
                    return true;
                }

                return false;
            }
    }
}