using ConwaysGameofLife.Persistence.Db;
using ConwaysGameofLife.Persistence.Entities;

namespace ConwaysGameofLife.Persistence.DAL
{
    public class BoardDAL: IBoardDAL
    {
        public BoardDAL(){}
        public int SaveBoardState(string board)
        {
            BoardEntity newBoard = new()
            {
                Board = board,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            using (var db = new GameOfLifeDb())
            {
                db.Add(newBoard);
                db.SaveChanges();
            };         

            return newBoard.Id;
        }
        public BoardEntity? GetBoardById(int boardId)
        {
            BoardEntity? board = null;
            using (var db = new GameOfLifeDb())
            {
                board = db.BoardsEntity
                    .FirstOrDefault(x => x.Id == boardId);
            };

            return board;
        }
        public bool UpdateBoardById(int boardId, string? board)
        {
            bool sucessfullUpdate = false;
            BoardEntity? currentBoard = null;

            using (var db = new GameOfLifeDb())
            {
                currentBoard = db.BoardsEntity.FirstOrDefault(x => x.Id == boardId);

                if(currentBoard != null)
                {
                    sucessfullUpdate = true;
                    currentBoard.Board = board;
                    currentBoard.UpdatedAt = DateTime.Now;
                    db.SaveChanges();
                }
            };

            return sucessfullUpdate;
        }
    }
}
