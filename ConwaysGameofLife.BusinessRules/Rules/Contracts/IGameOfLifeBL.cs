namespace ConwaysGameofLife.BusinessRules.Rules.Contracts
{
    public interface IGameOfLifeBL
    {
        string GetNewBoard(int rows, int cols);
        int UploadBoard(string board);
        string GetBoardById(int boardId);
        string GetNextGeneration(int boardId);
        int GetsNumberOfStatesAwayForBoardById(int boardId);
        string GetBoardFinalState(int boardId);
    }
}
