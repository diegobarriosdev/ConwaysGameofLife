using ConwaysGameofLife.BusinessRules.Mapper;
using ConwaysGameofLife.BusinessRules.Rules.Contracts;

namespace ConwaysGameofLife.BusinessRules.Rules
{
    public class GameOfLifeBL: IGameOfLifeBL
    {

        private readonly IBoardBL _boardBL;

        public GameOfLifeBL(IBoardBL boardBL) {
            _boardBL = boardBL;
        }
        
        public string GetNewBoard(int rows, int cols)
        {
            Random rand = new();
            bool[,] board = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Randomly initialize cells to be alive (true) or dead (false)
                    board[i, j] = rand.Next(2) == 0;
                }
            }
            return BoardMapper.ToJSon(board);
        }
        
        public int UploadBoard(string board)
        {
           var boardId = this._boardBL.SaveBoardState(board);
            return boardId;
        }
        
        public string GetBoardById(int boardId)
        {
            var board = this._boardBL.GetBoardById(boardId);
            return board;
        }
                
        public string GetNextGeneration(int boardId)
        {
            var board = 
                this._boardBL.GetFullBoardById(boardId);

            var newBoard = GetNextGeneration(board.Board, board.Rows, board.Cols);
            var newBoardStr = BoardMapper.ToJSon(newBoard);

            this._boardBL.UpdateBoard(boardId, newBoardStr);

            return newBoardStr;
        }

        public int GetsNumberOfStatesAwayForBoardById(int boardId)
        {
            var board =
                this._boardBL.GetFullBoardById(boardId);

            int numberofStatesAway = 0;
            int rows = board.Rows;
            int cols = board.Cols;
            bool[,] currentBoardState = board.Board;

            while (true)
            {
                bool[,] nextBoardState = GetNextGeneration(currentBoardState, rows, cols);

                if (BoardMapper.ToJSon(nextBoardState).Equals(BoardMapper.ToJSon(currentBoardState)))
                {
                    break;
                }
                numberofStatesAway++;
                currentBoardState = nextBoardState;
            };

            return numberofStatesAway;
        }

        public string GetBoardFinalState(int boardId)
        {
            var board =
                this._boardBL.GetFullBoardById(boardId);

            int rows = board.Rows;
            int cols = board.Cols;
            bool anyStateChange = true;
            bool[,] finalBoardState = null;
            bool[,] currentBoardState = board.Board;

            while (anyStateChange)
            {
                bool[,] nextBoardState = GetNextGeneration(currentBoardState, rows, cols);

                if (BoardMapper.ToJSon(nextBoardState).Equals(BoardMapper.ToJSon(currentBoardState)))
                {
                    anyStateChange = false;
                    finalBoardState = nextBoardState;
                }

                currentBoardState = nextBoardState;
            };

            return BoardMapper.ToJSon(finalBoardState);
        }

        #region helpers
        private bool[,] GetNextGeneration(bool[,] board, int rows, int cols)
        {
            bool[,] newBoard = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int liveNeighbors = CountLiveNeighbors(board, rows, cols, i, j);
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

            return newBoard;

        }

        private static int CountLiveNeighbors(bool[,] board, int rows, int cols, int x, int y)
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
        #endregion
    }
}
