using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            ShowMenu();

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                Game game = new Game();
                game.Run();
            }
            else if (key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.Clear();

        Console.WriteLine("================================");
        Console.WriteLine("           SNAKE GAME           ");
        Console.WriteLine("================================");
        Console.WriteLine();
        Console.WriteLine("  ENTER -> Jugar");
        Console.WriteLine("  ESC   -> Salir");
        Console.WriteLine();
        Console.WriteLine("================================");
    }
}