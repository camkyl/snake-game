using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Timers;

namespace SnakeGame
{
    public class Score
    {
        public int Points { get; }

        public Score(int score)
        {
            Points = score;
        }

        public void ShowScore(int score, int width)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(width / 2 - 8, 0);
            Console.WriteLine($"Your score is: {score - 4} ");
        }
    }
}