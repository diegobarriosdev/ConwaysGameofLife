using ConwaysGameofLife.BusinessRules.Mapper;
using ConwaysGameofLife.BusinessRules.Models;
using ConwaysGameofLife.BusinessRules.Rules.Contracts;
using ConwaysGameofLife.Persistence.DAL;

namespace ConwaysGameofLife.BusinessRules.Rules
{
    public class BoardBL : IBoardBL
    {
        private readonly IBoardDAL _boardDAL;

        public BoardBL(IBoardDAL boardDAL)
        {
            _boardDAL = boardDAL;
        }

        public string GetBoardById(int? id)
        {
            var boardModel = this.GetFullBoardById(id);
            string board = BoardMapper.ToJSon(boardModel.Board);
            return board;
        }

        public BoardModel? GetFullBoardById(int? id)
        {
            int boardId = id == null ? 0 : id.Value;
            
            if (boardId != 0)
            {
                var boardModel = BoardMapper.ToModel(_boardDAL.GetBoardById(boardId));
                return boardModel;
            }               

            return null;
        }

        public int SaveBoardState(string board)
        {
            return _boardDAL.SaveBoardState(board);
        }

        public bool UpdateBoard(int boardId, string board)
        {
            return _boardDAL.UpdateBoardById(boardId, board);
        }
    }
}
