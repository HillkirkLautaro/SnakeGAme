using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static int width = 40;
    static int height = 20;

    static List<(int x, int y)> snake = new List<(int, int)>();
    static int foodX;
    static int foodY;

    static int dx = 1;
    static int dy = 0;

    static bool gameOver = false;
    static Random rand = new Random();

    static void Main()
    {
        Console.CursorVisible = false;

        // Posición inicial
        snake.Add((10, 10));

        SpawnFood();

        while (!gameOver)
        {
            HandleInput();
            Update();
            Draw();
            Thread.Sleep(120);
        }

        Console.SetCursorPosition(0, height + 1);
        Console.WriteLine("Game Over");
    }

    static void HandleInput()
    {
        if (!Console.KeyAvailable)
            return;

        ConsoleKey key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.UpArrow && dy == 0)
        {
            dx = 0; dy = -1;
        }
        else if (key == ConsoleKey.DownArrow && dy == 0)
        {
            dx = 0; dy = 1;
        }
        else if (key == ConsoleKey.LeftArrow && dx == 0)
        {
            dx = -1; dy = 0;
        }
        else if (key == ConsoleKey.RightArrow && dx == 0)
        {
            dx = 1; dy = 0;
        }
    }

    static void Update()
    {
        int newX = snake[0].x + dx;
        int newY = snake[0].y + dy;

        // choque con pared
        if (newX < 0 || newX >= width || newY < 0 || newY >= height)
        {
            gameOver = true;
            return;
        }

        // choque consigo mismo
        foreach (var part in snake)
        {
            if (part.x == newX && part.y == newY)
            {
                gameOver = true;
                return;
            }
        }

        // mover snake
        snake.Insert(0, (newX, newY));

        // comer comida
        if (newX == foodX && newY == foodY)
        {
            SpawnFood();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }
    }

    static void Draw()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                bool drawn = false;

                // cabeza
                if (snake[0].x == x && snake[0].y == y)
                {
                    Console.Write("O");
                    continue;
                }

                // cuerpo
                foreach (var part in snake)
                {
                    if (part.x == x && part.y == y)
                    {
                        Console.Write("o");
                        drawn = true;
                        break;
                    }
                }

                if (drawn) continue;

                // comida
                if (x == foodX && y == foodY)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }

    static void SpawnFood()
    {
        bool valid = false;

        while (!valid)
        {
            int x = rand.Next(width);
            int y = rand.Next(height);

            valid = true;

            foreach (var part in snake)
            {
                if (part.x == x && part.y == y)
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
            {
                foodX = x;
                foodY = y;
            }
        }
    }
}