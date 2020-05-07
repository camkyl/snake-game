using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Timers;
using Time = System.Timers;

namespace SnakeGame // the correct one!
{
    class Program
    {
        static void Main(string[] args)
        {
            // Number of foods eaten and length of body
            int score = 4;

            // Size of game board
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            // Positioning snake in the middle of the game field
            int x = width / 2;
            int y = height / 2;

            // Starting game speed
            decimal gameSpeed = 150m;

            // Removes the marker that appears in front of the snake
            Console.CursorVisible = false;

            bool gameIsPlaying = true;
            bool wallIsHit;
            bool bodyIsHit;
            bool foodIsEaten;

            // Show current score on screen
            var currentScore = new Score(score);
            currentScore.ShowScore(score, width);

            // Draw game board 
            var gameBoard = new GameBoard(width, height);
            gameBoard.Draw();

            // Place snake on game board 
            var snake = new Snake(x, y, score);
            snake.DrawSnake();

            // Create food
            var food = new Food(width, height);
            food.DrawFood();

            // Read which key is pressed
            ConsoleKey direction = Console.ReadKey().Key;

            // Game loop
            while (gameIsPlaying)
            {
                // Detect if snake hits wall
                wallIsHit = snake.SnakeCollidedWithWall(snake.SnakeX, snake.SnakeY, height, width);
                
                if (wallIsHit)
                {
                    gameIsPlaying = false;
                    Console.SetCursorPosition(width / 2 - 16, height / 2 - 1);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("GAME OVER! The snake hit the wall :(");
                }

                // Detect if snake hits itself
                bodyIsHit = snake.SnakeCollidedWithItself(snake.SnakeX, snake.SnakeY);

                if(bodyIsHit)
                {
                    gameIsPlaying = false;
                    Console.SetCursorPosition(width / 2 - 16, height / 2 - 1);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("GAME OVER! The snake hit itself :(");
                }

                // Detect if apple was eaten
                foodIsEaten = food.FoodWasEaten(snake.SnakeX, snake.SnakeY, food.X, food.Y);

                if (foodIsEaten)
                {
                    // Keep track of how many foods were eaten + make snake longer
                    score++;

                    // Update score that is displayed on the screen
                    currentScore = new Score(score);
                    currentScore.ShowScore(score, width);

                    // Create new food item and draw it on the game board
                    food = new Food(width, height);
                    food.DrawFood();

                    // Make snake faster
                    gameSpeed *= 0.925m;
                }

                snake.DrawSnake();

                snake.MoveSnakeBody(foodIsEaten);

                // Change direction of snake
                switch (direction)
                {
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                    snake.Movement(direction);
                    break;
                }


                if (Console.KeyAvailable)
                {
                    direction = Console.ReadKey().Key;
                }

                // Slow down the game
                Thread.Sleep(Convert.ToInt32(gameSpeed));
            }

        } // end of Main()

    } // end of class Program
}