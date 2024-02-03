
namespace ConwaysGameOfLife.Console
{
    using System;

    class Program
        {
            static void Main(string[] args)
            {
                const int Rows = 3;
                const int Cols = 3;

                GameOfLife game = new GameOfLife(Rows, Cols);

                Console.WriteLine("Initial State:");
                PrintBoard(game.GetCurrentState());

                Console.WriteLine("\nPress any key to start the simulation...");
                Console.ReadKey();

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Current State:");
                    PrintBoard(game.GetCurrentState());
                    game.NextGeneration();
                    Console.WriteLine();
                    Console.WriteLine();

                System.Threading.Thread.Sleep(500); // Delay for visualization
                }
            }

            static void PrintBoard(bool[,] board)
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        Console.Write(board[i, j] ? "1" : "0"); // Print filled or empty square
                    }
                    Console.WriteLine();
                }
            }
        }

    public class GameOfLife
    {
        private readonly int rows;
        private readonly int cols;
        private bool[,] board;

        public GameOfLife(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.board = new bool[rows, cols];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Randomly initialize cells to be alive (true) or dead (false)
                    board[i, j] = rand.Next(2) == 0;
                }
            }
        }

        public bool[,] GetCurrentState()
        {
            return board;
        }

        public void NextGeneration()
        {
            bool[,] newBoard = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int liveNeighbors = CountLiveNeighbors(i, j);
                    if (board[i, j])
                    {
                        // Any live cell with fewer than two live neighbors dies (underpopulation)
                        // Any live cell with more than three live neighbors dies (overpopulation)
                        newBoard[i, j] = liveNeighbors == 2 || liveNeighbors == 3;
                    }
                    else
                    {
                        // Any dead cell with exactly three live neighbors becomes a live cell (reproduction)
                        newBoard[i, j] = liveNeighbors == 3;
                    }
                }
            }

            board = newBoard;
        }

        private int CountLiveNeighbors(int x, int y)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < rows && j >= 0 && j < cols && !(i == x && j == y) && board[i, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }

}
