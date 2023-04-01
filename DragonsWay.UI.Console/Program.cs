using DragonsWay.Logic;

Console.WriteLine("----------------------------------");
Console.WriteLine("*** Dragon's Way ***\n");

Console.Write("Enter the size of the maze: ");
int n = int.Parse(Console.ReadLine());
Console.Write("Enter the Dragon Path: ");
string pathDragon = Console.ReadLine();

var game = new Game(n, pathDragon);
//var game = new Game(10, "→→→↓↓↓→→→↓↓↓→→→→→→→→→↓→→→→→→");
//var game = new Game(10, "→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→→");
Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine(game);

Console.BackgroundColor = ConsoleColor.Black;
Console.WriteLine($"Game Win {game.Win()}\n");

if (game.Win())
{
    Console.WriteLine("The dragon is free!");
}
else
{
    Console.WriteLine("The dragon die... sorry");
}