using System;

namespace TicTacToe
{
    class Program
    {
        // Constant values for the size of the game board
        private const int ROWS = 3;
        private const int COLUMNS = 3;

        // 2D array to represent the game board
        private static char[,] board = new char[ROWS, COLUMNS];

        // Enum to represent the current player
        private enum Player
        {
            X, O
        }

        // Variable to store the current player
        private static Player currentPlayer = Player.X;

        static void Main(string[] args)
        {
            InitializeBoard();

            while (true)
            {
                PrintBoard();
                Console.WriteLine($"Player {currentPlayer}, enter your move (row column): ");
                int row = Convert.ToInt32(Console.ReadLine());
                int column = Convert.ToInt32(Console.ReadLine());
                if (MakeMove(row, column))
                {
                    if (CheckForWin())
                    {
                        PrintBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        break;
                    }
                    else if (IsBoardFull())
                    {
                        PrintBoard();
                        Console.WriteLine("It's a draw!");
                        break;
                    }
                    TogglePlayer();
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            }
        }

        private static void InitializeBoard()
        {
            // Initialize the board with empty spaces
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLUMNS; c++)
                {
                    board[r, c] = ' ';
                }
            }
        }

        private static void PrintBoard()
        {
            // Print the current state of the board
            for (int r = 0; r < ROWS; r++)
            {
                Console.WriteLine("-------------");
                for (int c = 0; c < COLUMNS; c++)
                {
                    Console.Write("| ");
                    Console.Write(board[r, c]);
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("-------------");
        }

        private static bool MakeMove(int row, int column)
        {
            // Check if the move is valid (within the bounds of the board and on an empty square)
            if (row >= 0 && row < ROWS && column >= 0 && column < COLUMNS && board[row, column] == ' ')
            {
                // Mark the square with the current player's symbol
                board[row, column] = currentPlayer == Player.X ? 'X' : 'O';
                return true;
            }

            return false;
        }

        private static bool CheckForWin()
        {
            // Check rows
            for (int r = 0; r < ROWS; r++)
            {
                if (board[r, 0] == board[r, 1] && board[r, 1] == board[r, 2] && board[r, 0] != ' ')
                {
                    return true;
                }
            }

            // Check columns
            for (int c = 0; c < COLUMNS; c++)
            {
                if (board[0, c] == board[1, c] && board[1, c] == board[2, c] && board[0, c] != ' ')
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
            {
                return true;
            }
            if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[2, 0] != ' ')
            {
                return true;
            }

            return false;
        }

        private static bool IsBoardFull()
        {
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLUMNS; c++)
                {
                    if (board[r, c] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void TogglePlayer()
        {
            currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
        }
    }
}

