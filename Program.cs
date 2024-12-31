Console.Title = "Tic Tac Toe";

Game game = new Game();

public class Game
{
    char currentPlayer {  get; set; }
    string winner { get; set; }
    List<char> grid = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    public Game()
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");
        Console.WriteLine("Player 1 will play as X and Player 2 will play as O.");
        currentPlayer = 'X';
        winner = "No Winner";

        Play();
    }

    public void Play()
    {
        // Main game loop
        while (winner == "No Winner")
        {
            DisplayGrid();

            int input = GetPlayerInput("Please select the number where you'd like to place your mark: ");

            grid[input] = currentPlayer;

            CheckWin();

            if (currentPlayer == 'X')
            {
                currentPlayer = 'O';
            }
            else
            {
                currentPlayer = 'X';
            }

            Console.Clear();
        }

        EndGame();
    }

    public void DisplayGrid()
    {
        Console.WriteLine();
        for (int i = 0; i < grid.Count; i++)
        {
            Console.Write($" {grid[i]} ");

            if ((i + 1) % 3 != 0) // Add a vertical divider between cells in the same row
                Console.Write("|");
            else
            {
                Console.WriteLine(); // Move to the next line after completing a row

                if (i < grid.Count - 1) // Add a horizontal divider after the row, except the last row
                    Console.WriteLine("---|---|---");
            }
        }
        Console.WriteLine();
    }

    public int GetPlayerInput(string question)
    {
        if (currentPlayer == 'X')
        {
            Console.Write($"Player 1, {question}");
        }
        else
        {
            Console.Write($"Player 2, {question}");
        }

        string answer = Console.ReadLine();

        if (!ValidateInput(answer))
        {
            Console.WriteLine("Must enter a number on the grid. Please try again.");
            return GetPlayerInput(question);
        }

        int index = int.Parse(answer) - 1;

        if (!ValidateIndex(index))
        {
            Console.WriteLine("The selected cell is already filled! Please select another.");
            return GetPlayerInput(question);
        }

        return index;


        bool ValidateInput(string answer)
        {
            if (!string.IsNullOrEmpty(answer) && answer.All(char.IsDigit))
            {
                int parsedAnswer = int.Parse(answer);
                return parsedAnswer >= 1 && parsedAnswer <= 9;
            }

            return false;
        }

        bool ValidateIndex(int index)
        {
            return char.IsDigit(grid[index]);
        }
    }

    public void CheckWin()
    {
        // Check rows
        if (grid[0] == grid[1] && grid[1] == grid[2])
        {
            if (grid[0] == 'X')
            {
                winner = "Player 1";
                return;
            }
            else
            {
                winner = "Player 2";
                return;
            }
        }

        if (grid[3] == grid[4] && grid[4] == grid[5])
        {
            if (grid[3] == 'X')
            {
                winner = "Player 1";
                return;
            }
            else
            {
                winner = "Player 2";
                return;
            }
        }

        if (grid[6] == grid[7] && grid[7] == grid[8])
        {
            if (grid[6] == 'X')
            {
                winner = "Player 1";
                return;
            }
            else
            {
                winner = "Player 2";
                return;
            }
        }

        // Check columns
        if (grid[0] == grid[3] && grid[3] == grid[6])
        {
            if(grid[0] == 'X')
            {
                winner = "Player 1";
                return;
            }
            else
            {
                winner = "Player 2";
                return;
            }
        }

        if (grid[1] == grid[4] && grid[4] == grid[7])
        {
            if (grid[1] == 'X')
            {
                winner = "Player 1";
                return;
            }
            else
            {
                winner = "Player 2";
                return;
            }
        }

        if (grid[2] == grid[5] && grid[5] == grid[8])
        {
            if (grid[2] == 'X')
            {
                winner = "Player 1";
                return;
            }
            else
            {
                winner = "Player 2";
                return;
            }
        }

        // Check diagonals
        if (grid[0] == grid[4] && grid[4] == grid[8])
        {
            if (grid[0] == 'X')
            {
                winner = "Player 1";
                return;
            }
            else
            {
                winner = "Player 2";
                return;
            }
        }

        if (grid[2] == grid[4] && grid[4] == grid[6])
        {
            if (grid[2] == 'X')
            {
                winner = "Player 1";
                return;
            }
            else
            {
                winner = "Player 2";
                return;
            }
        }

        // Check draw:
        if (!grid.Any(char.IsDigit))
        {
            winner = "Draw";
            return;
        }
    }

    public void EndGame()
    {
        Console.Clear();

        DisplayGrid();

        Console.WriteLine($"The winner is: {winner}");

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
