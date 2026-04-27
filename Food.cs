using System;

class Food
{
    public (int x, int y) Position { get; private set; }

    private int width;
    private int height;
    private Random rand = new();

    public Food(int width, int height, Snake snake)
    {
        this.width = width;
        this.height = height;
        Respawn(snake);
    }

    public void Respawn(Snake snake)
    {
        bool valid = false;

        while (!valid)
        {
            int x = rand.Next(width);
            int y = rand.Next(height);

            Position = (x, y);
            valid = true;
        }
    }
}