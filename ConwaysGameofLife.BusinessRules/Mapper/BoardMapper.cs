using ConwaysGameofLife.BusinessRules.Models;
using ConwaysGameofLife.Persistence.Entities;
using Newtonsoft.Json;

namespace ConwaysGameofLife.BusinessRules.Mapper
{
    public static class BoardMapper
    {
        public static BoardModel ToModel(BoardEntity board)
        {
            var boardModel = new BoardModel { 
                Id = board.Id,
                Board = MapTo2DArray(board.Board),
            };
            boardModel.Rows = boardModel.Board.GetLength(0);
            boardModel.Cols = boardModel.Board.GetLength(1);
            return boardModel;
        }

        public static BoardEntity ToEntity(BoardModel board) 
        {
            return new BoardEntity
            {
                Id = board.Id,
                Board = ToJSon(board.Board)
            };
        }

        public static string ToJSon(bool[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
        
            var array = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = matrix[i, j] == true ? 1 : 0;
                }
            }
        
            return JsonConvert.SerializeObject(array);
        }

        static bool[,] MapTo2DArray(string input)
        {
            // Remove outer brackets and split the input string by commas
            string[] rowStrings = input.Trim('[', ']').Split(new string[] { "],[" }, StringSplitOptions.None);

            int rowCount = rowStrings.Length;
            int colCount = rowStrings[0].Split(',').Length;

            bool[,] boolMatrix = new bool[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                // Split each row string by commas
                string[] elements = rowStrings[i].Split(',');

                for (int j = 0; j < colCount; j++)
                {
                    // Convert each element to a boolean value and assign it to the boolean matrix
                    boolMatrix[i, j] = elements[j] == "1";
                }
            }

            return boolMatrix;
        }

    }
}
