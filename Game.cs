using System;
using System.Threading;

class Game
{
    private int width = 40;
    private int height = 20;

    private Snake snake;
    private Food food;

    private bool gameOver = false;
    private int score = 0;
    private int speed = 120;

    public Game()
    {
        snake = new Snake(width, height);
        food = new Food(width, height, snake);
    }

    public void Run()
    {
        Console.CursorVisible = false;

        while (!gameOver)
        {
            HandleInput();
            Update();
            Draw();
            Thread.Sleep(speed);
        }

        Console.SetCursorPosition(0, height + 2);
        Console.WriteLine($"Game Over - Score: {score}");
        Console.WriteLine("Presiona una tecla para volver al menú...");
        Console.ReadKey();
    }

    private void HandleInput()
    {
        while (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            snake.ChangeDirection(key);
        }
    }

    private void Update()
    {
        snake.Move();

        if (snake.HasCollided(width, height))
        {
            gameOver = true;
            return;
        }

        if (snake.Eats(food.Position))
        {
            snake.Grow();
            food.Respawn(snake);
            score++;

            if (speed > 50)
                speed -= 3;
        }
    }

    private void Draw()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var pos = (x, y);

                if (snake.IsHead(pos))
                    Console.Write("O");
                else if (snake.IsBody(pos))
                    Console.Write("o");
                else if (food.Position == pos)
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }

        Console.WriteLine($"Score: {score}");
    }
}