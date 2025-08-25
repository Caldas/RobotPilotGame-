Game game = new Game();
game.PrintGameStartScreen();

Console.ReadKey();
Console.Clear();
//TODO: Start Game Logic Here

/// <summary>
/// Entry point for the PilotGame application.
/// </summary>
public class Game
{
    /// <summary>
    /// Displays the introductory screen for the game, including instructions and controls.
    /// </summary>
    /// <remarks>This method outputs a welcome message, a brief description of the game, and instructions  for
    /// navigating the robot using arrow keys. It also prompts the user to press any key to start the game.</remarks>
    public void PrintGameStartScreen()
    {
        Console.WriteLine("Hello Pilot, Welcome to our game!");
        Console.WriteLine("This is a simple console application to demonstrate C#.");
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("In this game, you will be able to navigate our robot (R) through a grid-based map.");
        Console.WriteLine("Let's get started with some basic commands.");
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Use the arrow keys to move the robot:");
        Console.WriteLine("  - Up Arrow: Move Up");
        Console.WriteLine("  - Down Arrow: Move Down");
        Console.WriteLine("  - Left Arrow: Move Left");
        Console.WriteLine("  - Right Arrow: Move Right");
        Console.WriteLine("Enjoy your game!");
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine("Press any key to start the game...");
    }
}