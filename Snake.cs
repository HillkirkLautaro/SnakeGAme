using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

class Snake
{
    private List<(int x, int y)> body = new();
    private int dx = 1;
    private int dy = 0;

    private bool grow = false;

    public Snake(int width, int height)
    {
        body.Add((width / 2, height / 2));
    }

    public void ChangeDirection(ConsoleKey key)
    {
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

    public void Move()
    {
        var head = body.First();
        var newHead = (head.x + dx, head.y + dy);

        body.Insert(0, newHead);

        if (!grow)
            body.RemoveAt(body.Count - 1);
        else
            grow = false;
    }

    public void Grow()
    {
        grow = true;
    }

    public bool HasCollided(int width, int height)
    {
        var head = body.First();

        if (head.x < 0 || head.x >= width || head.y < 0 || head.y >= height)
            return true;

        return body.Skip(1).Any(p => p == head);
    }

    public bool Eats((int x, int y) food)
    {
        return body.First() == food;
    }

    public bool IsHead((int x, int y) pos)
    {
        return body.First() == pos;
    }

    public bool IsBody((int x, int y) pos)
    {
        return body.Skip(1).Any(p => p == pos);
    }
}