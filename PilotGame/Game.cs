namespace PilotGame
{
    /// <summary>
    /// Represents the main logic and state for the PilotGame.
    /// Manages the 7x7 grid, robot, star, exit, and enemies, and provides methods for initializing the game,
    /// rendering the grid, handling user input, and checking for valid solutions.
    /// The class ensures that the robot can collect the star and reach the exit while avoiding enemies.
    /// </summary>
    public class Game
    {
        private const int GridSize = 7;
        private char[,] grid;
        private int robotX, robotY;
        private int exitX, exitY;
        private int starX, starY;
        private bool starCollected;
        private Random random;

        /// <summary>
        /// Initializes a new instance of the Game class.
        /// </summary>
        public Game()
        {
            grid = new char[GridSize, GridSize];
            random = new Random();
            InitializeGame();
        }

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

        /// <summary>
        /// Initializes the game state with an empty grid and sets up initial positions.
        /// </summary>
        private void InitializeGame()
        {
            // Initialize empty grid
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    grid[i, j] = '.';
                }
            }

            // Set robot starting position (top-left)
            robotX = 0;
            robotY = 0;

            // Set exit position (bottom-right)
            exitX = GridSize - 1;
            exitY = GridSize - 1;

            starCollected = false;

            // Place game elements
            DrawRobot();
            DrawExit();
            DrawStar();
            DrawEnemies();
        }

        /// <summary>
        /// Draws the robot at the top-left position of the grid.
        /// </summary>
        public void DrawRobot()
        {
            grid[robotY, robotX] = 'R';
        }

        /// <summary>
        /// Draws the exit at the bottom-right position of the grid.
        /// </summary>
        public void DrawExit()
        {
            grid[exitY, exitX] = 'E';
        }

        /// <summary>
        /// Draws the star randomly near the middle of the grid.
        /// </summary>
        public void DrawStar()
        {
            // Place star in middle area (positions 2-4 for both x and y)
            do
            {
                starX = random.Next(2, 5);
                starY = random.Next(2, 5);
            } while (grid[starY, starX] != '.');

            grid[starY, starX] = '*';
        }

        /// <summary>
        /// Draws 7 enemies randomly near the start position, ensuring a solution exists.
        /// </summary>
        public void DrawEnemies()
        {
            int maxAttempts = 50;
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                // Clear existing enemies
                for (int i = 0; i < GridSize; i++)
                {
                    for (int j = 0; j < GridSize; j++)
                    {
                        if (grid[i, j] == 'I')
                            grid[i, j] = '.';
                    }
                }

                // Place 7 enemies randomly near start
                int enemiesPlaced = 0;
                while (enemiesPlaced < 7)
                {
                    int x = random.Next(0, 5); // Slightly larger area
                    int y = random.Next(0, 5);

                    // Don't place on robot, exit, star, or existing enemy
                    if (grid[y, x] == '.')
                    {
                        grid[y, x] = 'I';
                        enemiesPlaced++;
                    }
                }

                // Check if this configuration has a solution
                if (CheckForSolutionInternal())
                {
                    return; // Found a valid configuration
                }

                attempts++;
            }

            // If we can't find a valid configuration, place fewer enemies
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (grid[i, j] == 'I')
                        grid[i, j] = '.';
                }
            }

            // Place only 3 enemies to ensure solution exists
            int simpleEnemies = 0;
            while (simpleEnemies < 3)
            {
                int x = random.Next(1, 4);
                int y = random.Next(1, 4);

                if (grid[y, x] == '.')
                {
                    grid[y, x] = 'I';
                    simpleEnemies++;
                }
            }
        }

        /// <summary>
        /// Internal solution check used during enemy placement.
        /// </summary>
        private bool CheckForSolutionInternal()
        {
            bool canReachStar = HasPath(robotX, robotY, starX, starY);
            bool canReachExit = HasPath(starX, starY, exitX, exitY);
            return canReachStar && canReachExit;
        }

        /// <summary>
        /// Draws the complete 7x7 grid to the console.
        /// </summary>
        public void DrawGrid()
        {
            Console.Clear();
            Console.WriteLine("Robot Pilot Game - Navigate to collect the star (*) and reach the exit (E)!");
            Console.WriteLine("R=Robot, *=Star, I=Enemy, E=Exit, .=Empty");
            Console.WriteLine();

            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }

            if (starCollected)
            {
                Console.WriteLine("\nStar collected! Now find the exit!");
            }
            else
            {
                Console.WriteLine("\nFind the star (*) first, then reach the exit (E)!");
            }
        }

        /// <summary>
        /// Checks if there is a valid solution path from robot to star to exit.
        /// </summary>
        /// <returns>True if a valid solution exists, false otherwise.</returns>
        public bool CheckForSolution()
        {
            return CheckForSolutionInternal();
        }

        /// <summary>
        /// Uses BFS to determine if there's a valid path between two points.
        /// </summary>
        private bool HasPath(int startX, int startY, int endX, int endY)
        {
            bool[,] visited = new bool[GridSize, GridSize];
            Queue<(int x, int y)> queue = new Queue<(int, int)>();

            queue.Enqueue((startX, startY));
            visited[startY, startX] = true;

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                if (x == endX && y == endY)
                    return true;

                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dx[i];
                    int newY = y + dy[i];

                    if (IsValidMove(newX, newY) && !visited[newY, newX])
                    {
                        visited[newY, newX] = true;
                        queue.Enqueue((newX, newY));
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a move to the specified coordinates is valid.
        /// </summary>
        private bool IsValidMove(int x, int y)
        {
            if (x < 0 || x >= GridSize || y < 0 || y >= GridSize)
                return false;

            // Can move to empty spaces, star, or exit, but not enemies
            return grid[y, x] != 'I';
        }

        /// <summary>
        /// Starts the main game loop.
        /// </summary>
        public void StartGame()
        {
            if (!CheckForSolution())
            {
                Console.WriteLine("No valid solution found! Regenerating level...");
                InitializeGame();
                StartGame();
                return;
            }

            bool gameRunning = true;
            while (gameRunning)
            {
                DrawGrid();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                int newX = robotX;
                int newY = robotY;

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        newY--;
                        break;
                    case ConsoleKey.DownArrow:
                        newY++;
                        break;
                    case ConsoleKey.LeftArrow:
                        newX--;
                        break;
                    case ConsoleKey.RightArrow:
                        newX++;
                        break;
                    case ConsoleKey.Escape:
                        gameRunning = false;
                        break;
                }

                if (IsValidMove(newX, newY))
                {
                    // Clear old robot position
                    grid[robotY, robotX] = '.';

                    // Check for star collection
                    if (newX == starX && newY == starY && !starCollected)
                    {
                        starCollected = true;
                    }

                    // Check for exit (only if star collected)
                    if (newX == exitX && newY == exitY && starCollected)
                    {
                        robotX = newX;
                        robotY = newY;
                        DrawRobot();
                        DrawGrid();
                        Console.WriteLine("\nCongratulations! You completed the mission!");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        gameRunning = false;
                        continue;
                    }

                    // Update robot position
                    robotX = newX;
                    robotY = newY;
                    DrawRobot();

                    // Redraw exit if robot moved away from it
                    if (grid[exitY, exitX] != 'E')
                    {
                        grid[exitY, exitX] = 'E';
                    }
                }
            }
        }
    }
}