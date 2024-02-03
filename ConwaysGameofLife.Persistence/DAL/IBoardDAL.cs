using ConwaysGameofLife.Persistence.Entities;

namespace ConwaysGameofLife.Persistence.DAL
{
    public interface IBoardDAL
    {
        int SaveBoardState(string board);
        BoardEntity? GetBoardById(int boardId);
        bool UpdateBoardById(int boardId, string? board);
    }
}
