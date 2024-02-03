using ConwaysGameofLife.BusinessRules.Models;

namespace ConwaysGameofLife.BusinessRules.Rules.Contracts
{
    public interface IBoardBL
    {
        int SaveBoardState(string board);        
        bool UpdateBoard(int boardId, string board);
        BoardModel? GetFullBoardById(int? id);
        string GetBoardById(int? id);
    }
}
