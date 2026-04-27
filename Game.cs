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
        Console.Clear();

        while (!gameOver)
        {
            HandleInput();
            Update();
            Draw();
            Thread.Sleep(speed);
        }

        Console.WriteLine();
        Console.WriteLine("Game Over");
        Console.WriteLine("Press any key...");
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

    string pad = GetPadding();
    string output = "";

    // borde superior
    output += pad + new string('#', width + 2) + "\n";

    for (int y = 0; y < height; y++)
    {
        output += pad + "#";

        for (int x = 0; x < width; x++)
        {
            var pos = (x, y);

            if (snake.IsHead(pos))
                output += "O";
            else if (snake.IsBody(pos))
                output += "o";
            else if (food.Position == pos)
                output += "*";
            else
                output += " ";
        }

        output += "#\n";
    }

    // borde inferior
    output += pad + new string('#', width + 2) + "\n\n";

    output += pad + $"Score: {score}";

    Console.Write(output);
}

    private string GetPadding()
    {
        int consoleWidth = Console.WindowWidth;
        int gameWidth = width + 2;

        int padding = Math.Max((consoleWidth - gameWidth) / 2, 0);
        return new string(' ', padding);
    }
}