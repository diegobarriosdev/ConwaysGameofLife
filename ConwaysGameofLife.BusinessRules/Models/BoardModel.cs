namespace ConwaysGameofLife.BusinessRules.Models
{
    public class BoardModel
    {
        public int Id { get; set; }
        public int Rows { get; set; }
        public int Cols { get; set; }
        public bool[,] Board { get; set; }

        // default ctr
        public BoardModel() { }

        public BoardModel(int rows, int cols): base()
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Board = new bool[rows, cols];
        }
        public BoardModel(bool[,] board) : base()
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            this.Rows = rows;
            this.Cols = cols;

            this.Board = board;
        }
    }
}
